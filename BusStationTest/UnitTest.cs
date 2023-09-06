using BusLibary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BusStationTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Add_Route_Eaquals()
        {
            int NumberRoute = 3;
            string FirstStation = "Пражская";
            string LastStation = "Академическая";
            int Mileage = 20;

            DataBaseRoute _base = new DataBaseRoute();

            _base.Add(NumberRoute, FirstStation, LastStation, Mileage);

            List<Route> list = new List<Route>();
           
            list.Equals(_base.RoutetList());

            _base.Delete(NumberRoute);

        }
        [TestMethod]
        public void Update_Route_Equals()
        {
            int ID_Route = 14;
            int NumberRoute = 30;
            string FirstStation = "test";
            string LastStation = "test";
            int Mileage = 20;

            DataBaseRoute _base = new DataBaseRoute();

            _base.Update(ID_Route, NumberRoute, FirstStation, LastStation, Mileage);

            List<Route> list = new List<Route>();

            list.Equals(_base.RoutetList());

            _base.Delete(NumberRoute);
        }
        [TestMethod]
        public void Delete_Route_Equals()
        {
            int NumberRoute = 44;
            string FirstStation = "test1";
            string LastStation = "test1";
            int Mileage = 20;

            DataBaseRoute _base = new DataBaseRoute();

            _base.Add(NumberRoute, FirstStation, LastStation, Mileage);

            List<Route> list = new List<Route>();

            list.Equals(_base.RoutetList());

            _base.Delete(NumberRoute);
        }

        [TestMethod]
        public void Show_Route_Equals()
        {
            //DataBaseRoute _base = new DataBaseRoute();
            StubRoute _base = new StubRoute();

            List<Route> list = new List<Route>();

            list.Equals(_base.RoutetList());

        }

        [TestMethod]
        public void Add_Driver_Eqauls()
        {
            string Name = "test";
            string Surname = "test";
            string Patronimic = "test";
            int NumberRoute_ID = 1;

            DataBaseDriver _base = new DataBaseDriver();

            _base.Add(Name, Surname, Patronimic, NumberRoute_ID);

            List<Driver> list = new List<Driver>();

            list.Equals(_base.DriverList());

            _base.Delete(Surname);
        }
        [TestMethod]
        public void Edit_Driver_Equals()
        {
            int ID_Driver = 3;
            string Name = "test";
            string Surname = "test";
            string Patronimic = "test";
            int NumberRoute_ID = 1;

            DataBaseDriver _base = new DataBaseDriver();

            _base.Update(ID_Driver, Name, Surname, Patronimic, NumberRoute_ID);

            List<Driver> list = new List<Driver>();

            list.Equals(_base.DriverList());

            _base.Delete(Surname);
        }
        [TestMethod]
        public void Delete_Driver_Equals()
        {
            string Name = "test";
            string Surname = "test";
            string Patronimic = "test";
            int NumberRoute_ID = 1;

            DataBaseDriver _base = new DataBaseDriver();

            _base.Add(Name, Surname, Patronimic, NumberRoute_ID);

            List<Driver> list = new List<Driver>();

            list.Equals(_base.DriverList());

            _base.Delete(Surname);
        }

        [TestMethod]
        public void Show_Driver_Equals()
        {
            //DataBaseDriver _base = new DataBaseDriver();
            StubDriver _base = new StubDriver();

            List<Driver> list = new List<Driver>();

            list.Equals(_base.DriverList());
        }
    }
}
