using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StudentManager_WPF.Models;

namespace StudentManager_WPF.DAL.Profesor
{
    public class ProfesorRepo : IProfesorRepo
    {
        private const string ImeParam = "@firstname";
        private const string PrezimeParam = "@lastname";
        private const string IdKolegijParam = "@kolegijID";
        private const string IdProfesorParam = "@idProfesor";

        private static string cs;

        public ProfesorRepo(string connString)
        {
            cs = connString;
        }

        public void AzurirajProfesora(Models.Profesor profesor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ImeParam, profesor.FirstName);
                    cmd.Parameters.AddWithValue(PrezimeParam, profesor.LastName);
                    cmd.Parameters.AddWithValue(IdKolegijParam, profesor.Kolegij.IDKolegij);
                    cmd.Parameters.AddWithValue(IdProfesorParam, profesor.IDProfesor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DodajProfesora(Models.Profesor profesor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ImeParam, profesor.FirstName);
                    cmd.Parameters.AddWithValue(PrezimeParam, profesor.LastName);
                    cmd.Parameters.AddWithValue(IdKolegijParam, profesor.Kolegij.IDKolegij);
                    SqlParameter idProfesor = new SqlParameter(IdProfesorParam, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idProfesor);
                    cmd.ExecuteNonQuery();
                    profesor.IDProfesor = (int)idProfesor.Value;
                }
            }
        }

        public Models.Profesor DohvatiProfesora(int idProfesor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdProfesorParam, idProfesor);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return KreirajProfesora(dr);
                        }
                    }
                }
            }
            throw new Exception("Profesor ne postoji");
        }

        public IList<Models.Profesor> DohvatiProfesore()
        {
            IList<Models.Profesor> profesori = new List<Models.Profesor>();

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
                            profesori.Add(KreirajProfesora(dr));
                        }
                    }
                }
            }

            return profesori;
        }

        public void IzbrisiProfesora(Models.Profesor profesor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdProfesorParam, profesor.IDProfesor);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Models.Profesor KreirajProfesora(SqlDataReader dr) => new Models.Profesor
        {
            IDProfesor = (int)dr[nameof(Models.Profesor.IDProfesor)],
            FirstName = dr[nameof(Models.Profesor.FirstName)].ToString(),
            LastName = dr[nameof(Models.Profesor.LastName)].ToString(),
            Kolegij = new Models.Kolegij
            {
                IDKolegij = (int)dr[nameof(Models.Kolegij.IDKolegij)],
                Naziv = dr[nameof(Models.Kolegij.Naziv)].ToString()
            }
        };
    }
}
