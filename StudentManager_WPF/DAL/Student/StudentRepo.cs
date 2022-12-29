using StudentManager_WPF.Models;
using StudentManager_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager_WPF.DAL.Student
{
    public class StudentRepo : IStudentRepo
    {

        private const string ImeParam = "@firstname";
        private const string PrezimeParam = "@lastname";
        private const string JmbagParam = "@jmbag";
        private const string PictureParam = "@picture";
        private const string IdKolegijParam = "@kolegijID";
        private const string IdStudentParam = "@idStudent";

        private static string cs;

        public StudentRepo(string connString)
        {
            cs = connString;
        }

        public void AzurirajStudenta(Models.Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ImeParam, student.FirstName);
                    cmd.Parameters.AddWithValue(PrezimeParam, student.LastName);
                    cmd.Parameters.AddWithValue(JmbagParam, student.Jmbag);
                    cmd.Parameters.AddWithValue(IdKolegijParam, student.Kolegij.IDKolegij);
                    cmd.Parameters.AddWithValue(IdStudentParam, student.IDStudent);
                    cmd.Parameters.Add(new SqlParameter(PictureParam, SqlDbType.Binary, student.Picture.Length)
                    {
                        Value = student.Picture
                    });
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DodajStudenta(Models.Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ImeParam, student.FirstName);
                    cmd.Parameters.AddWithValue(PrezimeParam, student.LastName);
                    cmd.Parameters.AddWithValue(JmbagParam, student.Jmbag);
                    cmd.Parameters.AddWithValue(IdKolegijParam, student.Kolegij.IDKolegij);
                    cmd.Parameters.Add(new SqlParameter(PictureParam, SqlDbType.Binary, student.Picture.Length)
                    {
                        Value = student.Picture
                    });
                    SqlParameter idStudent = new SqlParameter(IdStudentParam, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idStudent);
                    cmd.ExecuteNonQuery();
                    student.IDStudent = (int)idStudent.Value;
                }
            }
        }

        public Models.Student DohvatiStudenta(int idStudent)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdStudentParam, idStudent);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return KreirajStudenta(dr);
                        }
                    }
                }
            }
            throw new Exception("Student ne postoji");
        }

        public IList<Models.Student> DohvatiStudente()
        {
            IList<Models.Student> studenti = new List<Models.Student>();

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
                            studenti.Add(KreirajStudenta(dr));
                        }
                    }
                }
            }

            return studenti;
        }

        public void IzbrisiStudenta(Models.Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdStudentParam, student.IDStudent);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Models.Student KreirajStudenta(SqlDataReader dr) => new Models.Student
        {
            IDStudent = (int)dr[nameof(Models.Student.IDStudent)],
            FirstName = dr[nameof(Models.Student.FirstName)].ToString(),
            LastName = dr[nameof(Models.Student.LastName)].ToString(),
            Jmbag = dr[nameof(Models.Student.Jmbag)].ToString(),
            Kolegij = new Models.Kolegij
            {
                IDKolegij = (int)dr[nameof(Models.Kolegij.IDKolegij)],
                Naziv = dr[nameof(Models.Kolegij.Naziv)].ToString()
            },
            Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 4)
        };
    }
}
