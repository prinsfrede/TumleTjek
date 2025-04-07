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
    public class BarnRepo : IRepo<Barn>
    {
        private readonly string ConnectionString;
        private List<Barn> barns;
        public BarnRepo()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("TechnicalServices/appsettings.json")
                .Build();

            barns = new List<Barn>();

            ConnectionString = config.GetConnectionString("MyDBConnection");
        }


        public void Add(Barn ChildToBeCreated)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                
                using (SqlCommand command = new SqlCommand("INSERT INTO Barn (Name, Age, Forældre, IsSick) " + " VALUES (@Name, @Age, @Forældre, @IsSick)" + "SELECT @@IDENTITY", connection))
                {
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = ChildToBeCreated.Name;
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = ChildToBeCreated.Age;
                    string forældreinfo = $"{ChildToBeCreated.forældre.Name} ({ChildToBeCreated.forældre.PhoneNumber})";
                    command.Parameters.Add("@Forældre", SqlDbType.NVarChar).Value = forældreinfo;


                    command.Parameters.Add("@IsSick", SqlDbType.Bit).Value = ChildToBeCreated.IsSick;
                    ChildToBeCreated.BarnID = Convert.ToInt32(command.ExecuteScalar());
                    barns.Add(ChildToBeCreated);

                }
            }
        }

        public void Remove(Barn item)
        {
            barns.Remove(item);
        }

        public void Update(Barn item)
        {
            var index = barns.FindIndex(b => b.Name == item.Name);
            if (index != -1)
            {
                barns[index] = item;
            }
        }

        public Barn GetById(int id)
        {
            return barns.FirstOrDefault(b => b.Age == id);
        }

        public IEnumerable<Barn> GetAll()
        {
            return barns;
        }
    }

        


    
}
