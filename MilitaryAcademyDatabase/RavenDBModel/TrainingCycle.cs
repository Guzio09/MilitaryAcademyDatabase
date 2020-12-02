using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryAcademyDatabase.RavenDBModel
{
    public class TrainingCycle
    {
        public string Name { get; set; }
        public int StudentsCount { get; set; }
        public Academy AacademyId { get; set; }
    }
}
