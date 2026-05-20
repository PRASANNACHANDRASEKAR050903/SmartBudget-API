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
            catch
            {
                return false;
            }
        }

        // LOGIN
        public bool Login(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u =>
                u.Email == user.Email &&
                u.Password == user.Password);

            return existingUser != null;
        }
    }
}