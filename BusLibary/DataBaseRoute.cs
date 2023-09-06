using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLibary
{
    public class DataBaseRoute
    {
        static SqlConnection conn = new SqlConnection("Data Source=LAPTOP-7NUBAMDH\\SQLEXPRESS;Initial Catalog=BusStation;Persist Security Info=True;User ID=sa;Password=1111");

        public List<Route> RoutetList()
        {
            conn.Open();
            List<Route> routelist = new List<Route>();
            SqlCommand command = new SqlCommand("select *from [dbo].[Route]", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int NumberRoute = Convert.ToInt32(reader["NumberRoute"]);
                string FirstStation = reader["FirstStation"].ToString();
                string LastStation = reader["LastStation"].ToString();
                int Mileage = Convert.ToInt32(reader["Mileage"]);
                routelist.Add(new Route(NumberRoute, FirstStation, LastStation, Mileage));
            }
            reader.Close();
            conn.Close();
            return routelist;
        }
        public void Add(int NumberRoute, string FirstStation, string LastStation, int Mileage)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"insert into [dbo].[Route] ([NumberRoute],[FirstStation],[LastStation],[Mileage]) 
values (@NumberRoute,@FirstStation,@LastStation,@Mileage)", conn))
            {
                command.Parameters.Add("@NumberRoute", NumberRoute);
                command.Parameters.Add("@FirstStation", FirstStation);
                command.Parameters.Add("@LastStation", LastStation);
                command.Parameters.Add("@Mileage", Mileage);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void Update(int ID_Route, int NumberRoute, string FirstStation, string LastStation, int Mileage)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"update [dbo].[Route] set [NumberRoute] = @NumberRoute, [FirstStation] = @FirstStation, [LastStation] = @LastStation, [Mileage] = @Mileage where [ID_Route] = @ID_Route", conn))
            {
                command.Parameters.Add("@NumberRoute", NumberRoute);
                command.Parameters.Add("@FirstStation", FirstStation);
                command.Parameters.Add("@LastStation", LastStation);
                command.Parameters.Add("@Mileage", Mileage);
                command.Parameters.Add("@ID_Route", ID_Route);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void Delete(int NumberRoute)
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(@"delete [dbo].[Route] where [NumberRoute] = @NumberRoute", conn))
            {
                command.Parameters.Add("@NumberRoute", NumberRoute);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
