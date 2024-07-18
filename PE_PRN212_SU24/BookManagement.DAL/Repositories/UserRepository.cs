using BookManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.Repositories
{
    public class UserRepository
    {
        private BookManagementDbContext _context = new();

        public UserAccount? CheckLogin(string email, string password)
        {
            return _context.UserAccounts.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
