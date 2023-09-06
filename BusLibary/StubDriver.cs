using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLibary
{
    public class StubDriver
    {
        public List<Driver> DriverList()
        {
            List<Driver> routes = new List<Driver>();
            routes.Add(new Driver("Александр", "Иванов", "Евгениевич", 1));
            return routes;
        }
    }
}
