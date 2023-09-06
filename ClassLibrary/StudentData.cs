using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class StudentData
    {
        static SqlConnection conn = new SqlConnection("Data Source=LAPTOP-7NUBAMDH\\SQLEXPRESS;Initial Catalog=EducationalInstitution;Persist Security Info=True;User ID=sa;Password=1111");

        public List<Student> StudentList()
        {
            conn.Open();
            List<Student> studentlist = new List<Student>();
            SqlCommand command = new SqlCommand("select *from [dbo].[Student]", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string Name = reader["Name"].ToString();
                string Surname = reader["Surname"].ToString();
                string Patronymic = reader["Patronymic"].ToString();
                int Class_ID = Convert.ToInt32(reader["Class_ID"]);
                studentlist.Add(new Student(Name, Surname, Patronymic, Class_ID));
            }
            reader.Close();
            conn.Close();

            return studentlist;
        }


        public void Add(string Name, string Surname, string Patronymic, int Class_ID)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"insert into [dbo].[Student] ([Name],[Surname],[Patronymic],[Class_ID]) 
values (@Name,@Surname,@Patronymic,@Class_ID)", conn))
            {
                command.Parameters.Add("@Name", Name);
                command.Parameters.Add("@Surname", Surname);
                command.Parameters.Add("@Patronymic", Patronymic);
                command.Parameters.Add("@Class_ID", Class_ID);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void Update(int ID_Student, string Name, string Surname, string Patronymic, int Class_ID)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"update [dbo].[Student] set [Name] = @Name, [Surname] = @Surname, [Patronymic] = @Patronymic, [Class_ID] = @Class_ID where [ID_Student] = @ID_Student", conn))
            {
                command.Parameters.Add("@Name", Name);
                command.Parameters.Add("@Surname", Surname);
                command.Parameters.Add("@Patronymic", Patronymic);
                command.Parameters.Add("@Class_ID", Class_ID);
                command.Parameters.Add("@ID_Student", ID_Student);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void Delete(string Surname)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"delete [dbo].[Student] where [Surname] = @Surname", conn))
            {
                command.Parameters.Add("@Surname", Surname);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }


    }
}
