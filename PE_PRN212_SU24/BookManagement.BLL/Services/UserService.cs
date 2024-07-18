using BookManagement.DAL.Models;
using BookManagement.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.Services
{
    public class UserService
    {
        private UserRepository _repo = new();
        public UserAccount? CheckUserLogin(string email, string password)
        {
            return _repo.CheckLogin(email, password);
        }

    }
}
