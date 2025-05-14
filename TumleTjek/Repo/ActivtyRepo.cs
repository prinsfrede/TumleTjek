using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumleTjek.Model;
using Microsoft.Extensions.Configuration;
using System.IO;
using TumleTjek.TechnicalServices;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TumleTjek.Repo
{
    public class ActivtyRepo

    {
        private readonly string ConnectionString;
        private List<Activty> activities;
        public ActivtyRepo()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("TechnicalServices/appsettings.json")
                .Build();

            activities = new List<Activty>();

            ConnectionString = config.GetConnectionString("MyDBConnection");
        }
        public void Add(Activty ActivtyToBeCreated)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Activity (Name, Description, Location, Date, Duration) " + " VALUES (@Name, @Description, @Location, @Date, @Duration)" + "SELECT @@IDENTITY", connection))
                {
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ActivtyToBeCreated.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ActivtyToBeCreated.Description;
                    command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = ActivtyToBeCreated.Location;
                    command.Parameters.Add("@Date", SqlDbType.DateTime2).Value = ActivtyToBeCreated.Date;
                    command.Parameters.Add("@Duration", SqlDbType.NVarChar).Value = ActivtyToBeCreated.Duration;



                    ActivtyToBeCreated.ActivityID = Convert.ToInt32(command.ExecuteScalar());
                    activities.Add(ActivtyToBeCreated);

                }
            }
        }
        public void Remove(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM Activity WHERE ActivityID  = @ActivityID", connection);

                command.Parameters.AddWithValue("@ActivityID", id);

                command.ExecuteNonQuery();


            }
        }
        public void Update(Activty ActivtyToBeUpdated)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Activity SET Name = @Name, Description = @Description, Location = @Location, Date = @Date, Duration = @Duration WHERE ActivityID = @ActivityID", connection))
                {
                    command.Parameters.Add("@ActivityID", SqlDbType.Int).Value = ActivtyToBeUpdated.ActivityID;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ActivtyToBeUpdated.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ActivtyToBeUpdated.Description;
                    command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = ActivtyToBeUpdated.Location;
                    command.Parameters.Add("@Date", SqlDbType.DateTime2).Value = ActivtyToBeUpdated.Date;
                    command.Parameters.Add("@Duration", SqlDbType.NVarChar).Value = ActivtyToBeUpdated.Duration;

                    command.ExecuteNonQuery();
                }
            }

        }
        


    }
}
 