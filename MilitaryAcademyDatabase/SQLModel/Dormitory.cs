using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryAcademyDatabase.SQLModel
{
    public class Dormitory
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int RoomsCount { get; set; }
        public Academy Academy { get; set; }
        public List<Person> People { get; set; }
    }
}
