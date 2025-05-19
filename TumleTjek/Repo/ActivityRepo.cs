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
using System;
using System.Data.SqlClient;
using System.Windows;


namespace TumleTjek.Repo
{
    public interface IActivityRepo
    {
        void Add(Activity activityToBeCreated);
        void Update(Activity activityToBeUpdated);
        void Remove(int? id);
        IEnumerable<Activity> GetAllActivities();
    }

    public class ActivityRepo : IActivityRepo
    {
        private readonly string _connectionString;

        public ActivityRepo()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // Sørger for at appsettings findes under kørslen
                .AddJsonFile("TechnicalServices/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _connectionString = config.GetConnectionString("MyDBConnection");
        }

        public void Add(Activity activityToBeCreated)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Activity (Name, Description, Location, Date, Duration) " +
                                   "VALUES (@Name, @Description, @Location, @Date, @Duration); " +
                                   "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = activityToBeCreated.Name;
                        command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = activityToBeCreated.Description;
                        command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = activityToBeCreated.Location;
                        command.Parameters.Add("@Date", SqlDbType.DateTime2).Value = activityToBeCreated.Date;
                        command.Parameters.Add("@Duration", SqlDbType.NVarChar).Value = activityToBeCreated.Duration;

                        // Gem og hent det genererede ID
                        activityToBeCreated.ActivityID = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Der opstod en fejl under indsættelse af aktiviteten: " + ex.Message);
            }
        }

        public void Remove(int? id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Activity WHERE ActivityID = @ActivityID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ActivityID", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Der opstod en fejl under sletning af aktiviteten: " + ex.Message);
            }
        }

        public void Update(Activity activityToBeUpdated)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Activity SET Name = @Name, Description = @Description, Location = @Location, Date = @Date, Duration = @Duration " +
                                   "WHERE ActivityID = @ActivityID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ActivityID", SqlDbType.Int).Value = activityToBeUpdated.ActivityID;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = activityToBeUpdated.Name;
                        command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = activityToBeUpdated.Description;
                        command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = activityToBeUpdated.Location;
                        command.Parameters.Add("@Date", SqlDbType.DateTime2).Value = activityToBeUpdated.Date;
                        command.Parameters.Add("@Duration", SqlDbType.NVarChar).Value = activityToBeUpdated.Duration;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Der opstod en fejl under opdatering af aktiviteten: " + ex.Message);
            }
        }
        public IEnumerable<Activity> GetAllActivities()
        {
            var activities = new List<Activity>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT ActivityID, Name, Description, Date, Duration, Location FROM Activity";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                activities.Add(new Activity
                                {
                                    ActivityID = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Description = reader.GetString(2),
                                    Date = reader.GetDateTime(3),
                                    Duration = reader.GetString(4),
                                    Location = reader.GetString(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Fejl under hentning af aktiviteter: " + ex.Message);
            }
            return activities;
        }

    }

}
