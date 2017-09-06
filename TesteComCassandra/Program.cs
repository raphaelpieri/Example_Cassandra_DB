using System;
using Cassandra;
using Cassandra.Data.Linq;

namespace TesteComCassandra
{
    class Program
    {
        static void Main(string[] args)
        {
            var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();


            using (var session = cluster.Connect("demo"))
            {
                var repository = new UserRepository(session);

                //Insert
                repository.AddUser(new User("Rahael","De Pieri", 28, "t@t.com"));

                //Update
                repository.UpdateUser(new User("Raphael","Poi",40,"z@z.com"));

                //Select
                var user = repository.GetUser("Raphael");
                Console.WriteLine($"{user.FirstName} - {user.LastName}");

                //Remove
                repository.RemoveUser("Raphael");

                //Console.WriteLine($"{user.FirstName} - {user.LastName}");
                //Console.ReadKey();
            }
        }
    }
}