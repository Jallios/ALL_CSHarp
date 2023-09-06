using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalInstitution
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentData studentData = new StudentData();
            ClassData classData = new ClassData();

            Console.WriteLine("Добро пожаловать администратор!!!");
            Console.WriteLine("Данные успешно загружены!");
            for (int i = 0; i < studentData.StudentList().Count; i++)
            {
                Console.WriteLine(studentData.StudentList()[i].Name.ToString() + " " + studentData.StudentList()[i].Surname.ToString());
            }
            for (int i = 0; i < classData.ClassList().Count; i++)
            {
                Console.WriteLine(classData.ClassList()[i].NumberClass.ToString() + " " + classData.ClassList()[i].LetterClass.ToString());
            }
            Console.WriteLine("Какие будут ваши действия:" +
                "\n1.Добавть класс." +
                "\n2.Редактировать класс." +
                "\n3.Удалить класс." +
                "\n4.Добавть студента" +
                "\n5.Редактировать студента." +
                "\n6.Удалить студента.");
            int x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 1:
                    Console.WriteLine("Введите число класса: ");
                    int numClassAdd = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите букву класса: ");
                    string letClassAdd = Console.ReadLine();
                    classData.Add(numClassAdd, letClassAdd);
                    break;
                case 2:
                    Console.WriteLine("Введите id класса: ");
                    int idClassUp = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите число класса: ");
                    int numClassUp = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите букву класса: ");
                    string letClassUp = Console.ReadLine();
                    classData.Update(idClassUp, numClassUp, letClassUp);
                    break;
                case 3:
                    Console.WriteLine("Введите id класса: ");
                    int idClassDel = Convert.ToInt32(Console.ReadLine());
                    classData.Delete(idClassDel);
                    break;
                case 4:
                    Console.WriteLine("Введите имя: ");
                    string NameAdd = Console.ReadLine();
                    Console.WriteLine("Введите фамилию: ");
                    string SurnameAdd = Console.ReadLine();
                    Console.WriteLine("Введите отчество: ");
                    string PatronimicAdd = Console.ReadLine();
                    Console.WriteLine("Введите id класса: ");
                    int AddClass_ID = Convert.ToInt32(Console.ReadLine());
                    studentData.Add(NameAdd, SurnameAdd, PatronimicAdd, AddClass_ID);
                    break;
                case 5:
                    Console.WriteLine("Введите id студента: ");
                    int ID_Student = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите имя: ");
                    string NameUp = Console.ReadLine();
                    Console.WriteLine("Введите фамилию: ");
                    string SurnameUp = Console.ReadLine();
                    Console.WriteLine("Введите отчество: ");
                    string PatronimicUp = Console.ReadLine();
                    Console.WriteLine("Введите id класса: ");
                    int UpClass_ID = Convert.ToInt32(Console.ReadLine());
                    studentData.Update(ID_Student, NameUp, SurnameUp, PatronimicUp, UpClass_ID);
                    break;
                case 6:
                    Console.WriteLine("Введите id студента: ");
                    string SurnameDel = Console.ReadLine();
                    studentData.Delete(SurnameDel);
                    break;
            }
        }
    }
}
