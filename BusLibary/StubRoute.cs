using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLibary
{
    public class StubRoute
    { 
        public List<Route> RoutetList()
        {
            List<Route> routes = new List<Route>();
            routes.Add(new Route(11, "ст.Одинцово", "ЦРБ", 3));
            routes.Add(new Route(2, "test", "test", 15));
            routes.Add(new Route(21, "Пражская", "test", 20));
            return routes;
        }
    }
}
