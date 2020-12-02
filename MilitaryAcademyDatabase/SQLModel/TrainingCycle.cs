
using System.Collections.Generic;
using System.Text;

namespace MilitaryAcademyDatabase.SQLModel
{
    public class TrainingCycle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentsCount { get; set; }
        public Academy Academy { get; set; }
        public List<AcademyObject> AcademyObjects { get; set; }

        public List<Person> People { get; set; }
    }
}
