using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ClassData
    {
        static SqlConnection conn = new SqlConnection("Data Source=LAPTOP-7NUBAMDH\\SQLEXPRESS;Initial Catalog=EducationalInstitution;Persist Security Info=True;User ID=sa;Password=1111");

        public List<Class> ClassList()
        {
            conn.Open();
            List<Class> classlist = new List<Class>();
            SqlCommand command = new SqlCommand("select *from [dbo].[Class]", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int NumberClass = Convert.ToInt32(reader["NumberClass"]);
                string LetterClass = reader["LetterClass"].ToString();
                classlist.Add(new Class(NumberClass, LetterClass));
            }
            reader.Close();
            conn.Close();

            return classlist;
        }


        public void Add(int NumberClass, string LetterClass)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"insert into [dbo].[Class] ([NumberClass],[LetterClass])
values(@NumberClass,@LetterClass)", conn))
            {
                command.Parameters.Add("@NumberClass", NumberClass);
                command.Parameters.Add("@LetterClass", LetterClass);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void Update(int ID_Class, int NumberClass, string LetterClass)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"update [dbo].[Class] set [NumberClass] = @NumberClass, [LetterClass] = @LetterClass where [ID_Class] = @ID_Class", conn))
            {
                command.Parameters.Add("@ID_Class", ID_Class);
                command.Parameters.Add("@NumberClass", NumberClass);
                command.Parameters.Add("@LetterClass", LetterClass);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void Delete(int ID_Class)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"delete [dbo].[Class] where [ID_Class] = @ID_Class", conn))
            {
                command.Parameters.Add("@ID_Class", ID_Class);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

    }
}
