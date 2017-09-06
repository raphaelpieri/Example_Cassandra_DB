using System;
using System.Linq;
using Cassandra;

namespace TesteComCassandra
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession _session;

        public UserRepository(ISession session)
        {
            _session = session;
        }

        public void AddUser(User user)
        {
            _session.Execute($"insert into users (first_name, last_name, age, email) values ('{user.FirstName}', '{user.LastName}', {user.Age}, '{user.Email}')");
        }

        public void UpdateUser(User user)
        {
            _session.Execute(
                $"update users set age = {user.Age}, email = '{user.Email}', last_name = '{user.LastName}' WHERE first_name = '{user.FirstName}'");
        }

        public User GetUser(string firstName)
        {
            var result = _session.Execute($"SELECT * FROM users WHERE first_name = '{firstName}'").First();

            var first_name = Convert.ToString(result["first_name"]);
            var last_name = Convert.ToString(result["last_name"]);
            var age = Convert.ToInt32(result["age"]);
            var email = Convert.ToString(result["email"]);

            return new User(first_name, last_name, age, email);
        }

        public void RemoveUser(string firstName)
        {
            _session.Execute($"DELETE FROM users WHERE first_name = '{firstName}'");
        }
    }
}