using BookManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repositories
{
    public class BookRepository
    {
        private BookManagementDbContext _context;

        public List<Book> GetAll()
        {
            _context = new BookManagementDbContext();
            //return _context.Books.ToList();
            // convert vef list 
            // Lazy loading hear 
            // dù đã có sẵn cơ sỡ dữ liệu
            // nếu ta muốn lấy cả category thì ta phải join cả bảng và kêu goi performance
            // Navigation Path 
            return _context.Books.Include("BookCategory").ToList();
        }
        public Book Get(int id)
        {
            _context = new BookManagementDbContext();
            return _context.Books.Include(b => b.BookCategory).FirstOrDefault(b => b.BookId == id);
        }

        public List<Book> Search(string keyword)
        {
            _context = new BookManagementDbContext();
            return _context.Books.Include(b => b.BookCategory)
                                 .Where(b => b.BookName
                                 .Contains(keyword)
                                 || b.Description
                                 .Contains(keyword))
                                 .ToList();
        }

        public void Add(Book book)
        {
            _context = new BookManagementDbContext();
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void Update(Book book)
        {
            _context = new BookManagementDbContext();
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            _context = new BookManagementDbContext();
            //var book = _context.Books.FirstOrDefault(b => b.BookId == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
