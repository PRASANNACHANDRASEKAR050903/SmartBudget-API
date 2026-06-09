using SmartBudget.API.Data;
using SmartBudget.API.Models;

namespace SmartBudget.API.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Register(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("REGISTRATION ERROR:");
                Console.WriteLine(ex.ToString());

                throw;
            }
        }

        public User? Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(x =>
                x.Email == email &&
                x.Password == password);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}