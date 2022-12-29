using StudentManager_WPF.DAL.Kolegij;
using StudentManager_WPF.DAL.Profesor;
using StudentManager_WPF.DAL.Student;
using System;
using System.Configuration;

namespace StudentManager_WPF.DAL
{
    static class RepoFactory
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        private static readonly Lazy<IStudentRepo> studentRepo = new Lazy<IStudentRepo>(() => new StudentRepo(cs));
        public static IStudentRepo GetStudentRepo() => studentRepo.Value;

        private static readonly Lazy<IProfesorRepo> profesorRepo = new Lazy<IProfesorRepo>(() => new ProfesorRepo(cs));
        public static IProfesorRepo GetProfesorRepo() => profesorRepo.Value;

        private static readonly Lazy<IKolegijRepo> kolegijRepo = new Lazy<IKolegijRepo>(() => new KolegijRepo(cs));
        public static IKolegijRepo GetKolegijRepo() => kolegijRepo.Value;
    }
}
