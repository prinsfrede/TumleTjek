using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using TumleTjek;
using TumleTjek.Model;
using TumleTjek.Repo;
using TumleTjek.ViewModel;

namespace TestProject2
{
    [TestClass]
    public sealed class Test1
    {
        private readonly string ConnectionString;
       
        public Test1()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("TechnicalServices/appsettings.json")
                .Build();

           

            ConnectionString = config.GetConnectionString("MyDBConnection");
        }
        [TestMethod]
        public void TestMethod1()
        {
            var existingchild = 100;
            var repo = new ChildRepo();
            var name = "Test";

            var originalchild = new Child
            {
                ChildID = existingchild,
                Name = name,
                Age = 4,
                Parents = new Parent { Name = "test", PhoneNumber = "0000000" },
                Details = "Test Details",
                IsMet = false
            };

            repo.Add(originalchild);

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Name, Age FROM Child WHERE Name = @Name" , connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        Assert.IsTrue(reader.Read());

                        var dbName = reader["Name"].ToString();
                        var dbAge = reader["Age"].ToString();

                        Assert.AreEqual("test", dbName);
                        Assert.AreEqual("4", dbAge);

                    }
                }
            }


        }
    }
}
