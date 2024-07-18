using BookManagement.DAL.Models;
using BookManagement.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.Services
{
    public class BookCategoryService
    {
        private BookCategoryReponsitory _repo = new();

        public List<BookCategory> GetAllCategory()
        {
            return _repo.GetAll();
        }
        // No' goi repo va GUI goi no 
        // GUI--> Service -Here  --> Repo --> Context
    }
}
