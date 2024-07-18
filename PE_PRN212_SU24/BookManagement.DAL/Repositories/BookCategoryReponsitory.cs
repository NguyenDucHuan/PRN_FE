using BookManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.Repositories
{
    public class BookCategoryReponsitory
    {
        private BookManagementDbContext _db;

        public List<BookCategory> GetAll()
        {
            _db = new BookManagementDbContext();
            return _db.BookCategories.ToList();
        }
    }
}
