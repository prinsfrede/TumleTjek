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
    public class BarnRepo : IRepo<Child>
    {
        private readonly string ConnectionString;
        private List<Child> children;
        public BarnRepo()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("TechnicalServices/appsettings.json")
                .Build();

            children = new List<Child>();

            ConnectionString = config.GetConnectionString("MyDBConnection");
        }


        public void Add(Child ChildToBeCreated)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Child (Name, Age, ParentsName, ParentsPhoneNumber, IsMet, Details) " + " VALUES (@Name, @Age, @ParentsName, @ParentsPhoneNumber, @IsMet, @Details)" + "SELECT @@IDENTITY", connection))
                {
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ChildToBeCreated.Name;
                   
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = ChildToBeCreated.Age;
                    command.Parameters.Add("@ParentsName", SqlDbType.NVarChar).Value = ChildToBeCreated.Parents.Name;
                    command.Parameters.Add("@ParentsPhoneNumber", SqlDbType.NVarChar).Value = ChildToBeCreated.Parents.PhoneNumber;
                    command.Parameters.Add("@IsMet", SqlDbType.Bit).Value = ChildToBeCreated.IsMet = false;
                    command.Parameters.Add("@Details", SqlDbType.NVarChar).Value = ChildToBeCreated.Details = "";

                    ChildToBeCreated.ChildID = Convert.ToInt32(command.ExecuteScalar());
                    children.Add(ChildToBeCreated);

                }
            }
        }

        public void Remove(Child item)
        {
            children.Remove(item);
        }

        public void Update(Child ChildToBeUpdated)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Child SET Name = @Name, Age = @Age, ParentsName = @ParentsName, ParentsPhoneNumber = @ParentsPhoneNumber, Details = @Details, IsMet = @IsMet WHERE ChildID = @ChildID", connection))
                {
                    command.Parameters.Add("@ChildID", SqlDbType.Int).Value = ChildToBeUpdated.ChildID;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ChildToBeUpdated.Name;
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = ChildToBeUpdated.Age;
                    command.Parameters.Add("@ParentsName", SqlDbType.NVarChar).Value = ChildToBeUpdated.Parents.Name;
                    command.Parameters.Add("@ParentsPhoneNumber", SqlDbType.NVarChar).Value = ChildToBeUpdated.Parents.PhoneNumber;
                    command.Parameters.Add("@Details", SqlDbType.NVarChar).Value = ChildToBeUpdated.Details ?? "";
                    command.Parameters.Add("@IsMet", SqlDbType.Bit).Value = ChildToBeUpdated.IsMet;

                    command.ExecuteNonQuery();
                }
            }

        }

        public Child GetById(int id)
        {
            return children.FirstOrDefault(b => b.Age == id);
        }

        public List<Child> GetAll()
        {
            List<Child> barns = new List<Child>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT  ChildID ,Name, Age, ParentsName, ParentsPhoneNumber, IsMet from Child", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Child barn = new Child
                            {
                                ChildID = reader.IsDBNull(0) ? (int?)null : reader.GetInt32(0),
                                Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                                Age = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                Parents = new Forældre
                                {
                                    Name = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    PhoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4)

                                },
                                IsMet = reader.IsDBNull(5) ? (bool?)null : reader.GetBoolean(5)
                            };
                            barns.Add(barn);
                        }
                    }
                }
                
            }
            return barns;
        }
    }
}






