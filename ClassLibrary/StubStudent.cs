using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class StubStudent
    {
        public List<Student> StudentList()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("test", "test", "test", 1));
            return students;
        }
    }
}
