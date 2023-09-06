using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLibary
{
    public class DataBaseDriver
    {
        static SqlConnection conn = new SqlConnection("Data Source=LAPTOP-7NUBAMDH\\SQLEXPRESS;Initial Catalog=BusStation;Persist Security Info=True;User ID=sa;Password=1111");

        public List<Driver> DriverList()
        {
            conn.Open();
            List<Driver> driverlist = new List<Driver>();
            SqlCommand command = new SqlCommand("select *from [dbo].[Driver]", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string Name = reader["Name"].ToString();
                string Surname = reader["Surname"].ToString();
                string Patronymic = reader["Patronymic"].ToString();
                int NumberRoute_ID = Convert.ToInt32(reader["NumberRoute_ID"]);
                driverlist.Add(new Driver(Name, Surname, Patronymic, NumberRoute_ID));
            }
            reader.Close();
            conn.Close();

            return driverlist;
        }


        public void Add(string Name, string Surname, string Patronymic, int NumberRoute_ID)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"insert into [dbo].[Driver] ([Name],[Surname],[Patronymic],[NumberRoute_ID]) 
values (@Name,@Surname,@Patronymic,@NumberRoute_ID)", conn))
            {
                command.Parameters.Add("@Name", Name);
                command.Parameters.Add("@Surname", Surname);
                command.Parameters.Add("@Patronymic", Patronymic);
                command.Parameters.Add("@NumberRoute_ID", NumberRoute_ID);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void Update(int ID_Driver, string Name, string Surname, string Patronymic, int NumberRoute_ID)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"update [dbo].[Driver] set [Name] = @Name, [Surname] = @Surname, [Patronymic] = @Patronymic, [NumberRoute_ID] = @NumberRoute_ID where [ID_Driver] = @ID_Driver", conn))
            {
                command.Parameters.Add("@Name", Name);
                command.Parameters.Add("@Surname", Surname);
                command.Parameters.Add("@Patronymic", Patronymic);
                command.Parameters.Add("@NumberRoute_ID", NumberRoute_ID);
                command.Parameters.Add("@ID_Driver", ID_Driver);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void Delete(string Surname)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"delete [dbo].[Driver] where [Surname] = @Surname", conn))
            {
                command.Parameters.Add("@Surname", Surname);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }


    }
}
