namespace TesteComCassandra
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        User GetUser(string firstName);
        void RemoveUser(string firstName);
    }
}