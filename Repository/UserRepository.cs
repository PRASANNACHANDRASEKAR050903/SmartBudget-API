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

        // REGISTER
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
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // LOGIN
        public User? Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(u =>
                u.Email == email &&
                u.Password == password);
        }

        // GET ALL USERS
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}