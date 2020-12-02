using MilitaryAcademyDatabase.SQLModel;
using Raven.Client.Documents;
using System;
using System.Data.Entity;
using System.Linq;

namespace MilitaryAcademyDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var querries = new Queries();
            querries.SQLQueries();
            querries.RavenDBQueries();
        }
    }

    public static class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    Urls = new[] { "http://127.0.0.1:8080/" },
                    Database = "MilitaryAcademyDatabase",
                };

                return store.Initialize();
            });

        public static IDocumentStore Store => LazyStore.Value;
    }

    public class MilitaryAcademyDatabaseContext : DbContext
    {
        public DbSet<Academy> Academies { get; set; }
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<TrainingCycle> TrainingCycles { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<AcademyObject> AcademyObjects { get; set; }

    }
}
