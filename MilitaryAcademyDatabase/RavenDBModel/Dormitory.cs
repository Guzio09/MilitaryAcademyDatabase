using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryAcademyDatabase.RavenDBModel
{
    public class Dormitory
    {
        public string Street { get; set; }
        public int RoomsCount { get; set; }
        public Academy AcademyId { get; set; }
    }
}
