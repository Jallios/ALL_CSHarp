using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EducationalInstitutionTest
{
    [TestClass]
    public class EdItTest
    {
        //Class
        [TestMethod]
        public void Add_Class_Eaquals()
        {
            int NumberClass = 3;
            string LetterClass = "A";

            ClassData _base = new ClassData();

            _base.Add(NumberClass, LetterClass);

            List<Class> list = new List<Class>();

            list.Equals(_base.ClassList());
        }
        [TestMethod]
        public void Update_Class_Equals()
        {
            int ID_Class = 3;
            int NumberClass = 5;
            string LetterClass = "B";

            ClassData _base = new ClassData();

            _base.Update(ID_Class, NumberClass, LetterClass);

            List<Class> list = new List<Class>();

            list.Equals(_base.ClassList());
        }
        [TestMethod]
        public void Delete_Class_Equals()
        {
            int ID_Class = 3;

            ClassData _base = new ClassData();

            _base.Delete(ID_Class);

            List<Class> list = new List<Class>();

            list.Equals(_base.ClassList());
        }

        [TestMethod]
        public void Show_Class_Equals()
        {
            //Class _base = new Class();
            StubClass _base = new StubClass();

            List<Class> list = new List<Class>();

            list.Equals(_base.ClassList());

        }

        //Student
        [TestMethod]
        public void Add_Student_Eqauls()
        {
            string Name = "testC";
            string Surname = "testC";
            string Patronimic = "testC";
            int Class_ID = 1;

            StudentData _base = new StudentData();

            _base.Add(Name, Surname, Patronimic, Class_ID);

            List<Student> list = new List<Student>();

            list.Equals(_base.StudentList());
        }
        [TestMethod]
        public void Edit_Student_Equals()
        {
            int ID_Student = 3;
            string Name = "testC2";
            string Surname = "testC2";
            string Patronimic = "testC2";
            int Class_ID = 1;

            StudentData _base = new StudentData();

            _base.Update(ID_Student, Name, Surname, Patronimic, Class_ID);

            List<Student> list = new List<Student>();

            list.Equals(_base.StudentList());
        }
        [TestMethod]
        public void Delete_Student_Equals()
        {
            string Surname = "testC2";

            StudentData _base = new StudentData();

            _base.Delete(Surname);

            List<Student> list = new List<Student>();

            list.Equals(_base.StudentList());
        }

        [TestMethod]
        public void Show_Student_Equals()
        {
            //StudentData _base = new StudentData();
            StubStudent _base = new StubStudent();

            List<Student> list = new List<Student>();

            list.Equals(_base.StudentList());
        }
    }
}
