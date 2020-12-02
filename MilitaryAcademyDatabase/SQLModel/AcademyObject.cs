
using System.Collections.Generic;
using System.Text;

namespace MilitaryAcademyDatabase.SQLModel
{
    public class AcademyObject
    {
        public int Id { get; set; }
        public string ObjectName { get; set; }
        public string Street { get; set; }
        public int Slots { get; set; }
        public TrainingCycle TrainingCycle { get; set; }
    }
}
