using Raven.Client.Documents.Session;
using System;
using System.Diagnostics;
using System.Linq;

namespace MilitaryAcademyDatabase
{
    public class Queries
    {
        readonly MilitaryAcademyDatabaseContext databaseContext = new MilitaryAcademyDatabaseContext();
        public void SQLQueries()
        {
            var timerSQLFirstQuery = Stopwatch.StartNew();
            var firstResult = databaseContext.Dormitories
                .GroupBy(x => x.Academy)
                .Select(x => new
                {
                    AcademyName = x.Key.Name,
                    PeopleCount = x.Key.Dormitories.
                    Select(x => x.People.Count()).Sum()
                })
                .OrderByDescending(x => x.PeopleCount)
                .ToList();
            timerSQLFirstQuery.Stop();

            var timerSQLSecondQuery = Stopwatch.StartNew();
            var secondResult = databaseContext.People
                .GroupBy(x => x.PersonRank)
                .Select(x => new
                {
                    AcademyName = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .ToList();
            timerSQLSecondQuery.Stop();

            var timerSQLThirdQuery = Stopwatch.StartNew();
            var thirdResult = databaseContext.TrainingCycles
                .Select(x => new
                {
                    Name = x,
                    Students = x.People.Count()
                })
                .OrderByDescending(x => x.Students)
                .ToList();
            timerSQLThirdQuery.Stop();

            Console.WriteLine("SQL First Query: " + timerSQLFirstQuery.ElapsedMilliseconds);
            Console.WriteLine("SQL Second Query: " + timerSQLSecondQuery.ElapsedMilliseconds);
            Console.WriteLine("SQL Third Query: " + timerSQLThirdQuery.ElapsedMilliseconds);
        }

        public void RavenDBQueries()
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                var timerRavenDBFirstQuery = Stopwatch.StartNew();
                var firstResult = session
                    .Query<RavenDBModel.Person>()
                    .GroupBy(x => x.DormitoryId.AcademyId.Name)
                .Select(x => new
                {
                    AcademyName = x.Key,
                    PeopleCount = x.Count()
                })
                .OrderByDescending(x => x.PeopleCount)
                .ToList();
                timerRavenDBFirstQuery.Stop();

                var timerRavenDBSecondQuery = Stopwatch.StartNew();
                var secondResult = session
                   .Query<RavenDBModel.Person>()
                   .GroupBy(x => x.PersonRank)
               .Select(x => new
               {
                   Rank = x.Key,
                   Count = x.Key.Count()
               })
               .OrderByDescending(x => x.Count)
               .ToList();
                timerRavenDBSecondQuery.Stop();

                var timerRavenDBThirdQuery = Stopwatch.StartNew();
                var thirdResult = session
                    .Query<RavenDBModel.Person>()
                    .GroupBy(x => x.TrainingCycleId)
                .Select(x => new
                {
                    TrainingCycleName = x.Key,
                    PeopleCount = x.Count(),
                })
                .OrderByDescending(x => x.PeopleCount)
                .ToList();
                timerRavenDBThirdQuery.Stop();

                Console.WriteLine("RavenDB First Query: " + timerRavenDBFirstQuery.ElapsedMilliseconds);
                Console.WriteLine("RavenDB Second Query: " + timerRavenDBSecondQuery.ElapsedMilliseconds);
                Console.WriteLine("RavenDB Third Query: " + timerRavenDBThirdQuery.ElapsedMilliseconds);
            }
        }
    }
}
