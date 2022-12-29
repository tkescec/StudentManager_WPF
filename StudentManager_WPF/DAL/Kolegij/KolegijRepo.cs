using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager_WPF.DAL.Kolegij
{
    public class KolegijRepo : IKolegijRepo
    {
        private const string NazivParam = "@Naziv";
        private const string IdKolegijParam = "@idKolegij";

        private static string cs;

        public KolegijRepo(string connString)
        {
            cs = connString;
        }

        public void AzurirajKolegij(Models.Kolegij kolegij)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(NazivParam, kolegij.Naziv);
                    cmd.Parameters.AddWithValue(IdKolegijParam, kolegij.IDKolegij);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DodajKolegij(Models.Kolegij kolegij)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(NazivParam, kolegij.Naziv);
                    SqlParameter idKolegij = new SqlParameter(IdKolegijParam, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idKolegij);
                    cmd.ExecuteNonQuery();
                    kolegij.IDKolegij = (int)idKolegij.Value;
                }
            }
        }

        public Models.Kolegij DohvatiKolegij(int idKolegij)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdKolegijParam, idKolegij);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return KreirajKolegij(dr);
                        }
                    }
                }
            }
            throw new Exception("Kolegij ne postoji");
        }

        public IList<Models.Kolegij> DohvatiKolegije()
        {
            IList<Models.Kolegij> kolegiji = new List<Models.Kolegij>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            kolegiji.Add(KreirajKolegij(dr));
                        }
                    }
                }
            }

            return kolegiji;
        }

        public void IzbrisiKolegij(Models.Kolegij kolegij)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdKolegijParam, kolegij.IDKolegij);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Models.Kolegij KreirajKolegij(SqlDataReader dr) => new Models.Kolegij
        {
            IDKolegij = (int)dr[nameof(Models.Kolegij.IDKolegij)],
            Naziv = dr[nameof(Models.Kolegij.Naziv)].ToString()
        };
    }
}
