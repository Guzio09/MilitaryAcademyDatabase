using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryAcademyDatabase.RavenDBModel
{
    public class Person
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PersonType { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonRank { get; set; }
        public Dormitory DormitoryId { get; set; }
        public TrainingCycle TrainingCycleId { get; set; }
    }
}
