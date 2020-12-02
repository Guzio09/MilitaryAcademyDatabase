using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryAcademyDatabase.RavenDBModel
{
    public class AcademyObject
    {
        public string ObjectName { get; set; }
        public string Street { get; set; }
        public int Slots { get; set; }
        public TrainingCycle TrainingCycleId { get; set; }
    }
}
