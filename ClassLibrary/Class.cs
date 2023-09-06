using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Class
    {
        public int NumberClass { get; set; }
        public string LetterClass { get; set; }
       
        public Class(int NumberClass, string LetterClass)
        {
            this.NumberClass = NumberClass;
            this.LetterClass = LetterClass;
        }
    }
}
