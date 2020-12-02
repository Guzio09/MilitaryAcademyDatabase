
using System.Collections.Generic;
using System.Text;

namespace MilitaryAcademyDatabase.SQLModel
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PersonType { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonRank { get; set; }
        public Dormitory Dormitory { get; set; }
        public TrainingCycle TrainingCycle { get; set; }
    }
}
