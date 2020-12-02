using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryAcademyDatabase.SQLModel
{
    public class Academy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public List<Dormitory> Dormitories { get; set; }
        public List<TrainingCycle> TrainingCycles { get; set; }
    }
}
