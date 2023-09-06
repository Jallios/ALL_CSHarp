using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class StubClass
    {
        public List<Class> ClassList()
        {
            List<Class> _class = new List<Class>();
            _class.Add(new Class(4, "T"));
            return _class;
        }
    }
}
