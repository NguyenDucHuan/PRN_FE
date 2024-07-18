using BookManagement.DAL.Models;
using BookManagement.DAL.Repositories;

namespace BookManagement.BLL.Services
{
    public class BookService
    {
        private BookRepository _repo = new(); //new luôn
        //các hàm crud book trong ram đều nhờ cậy từ repo
        //đặt tên hàm 
        //GUI WPF -> Service(BLL) -> Repository(DAL) -> DBContext -> DB
        //class này lại cũng là 1 dạng cabinet nhưng chỉ chơi với table book
        //nook chơi trong ram và tính toán gì đó trở lại GUI hoặc lấy từ GUI xuống repository => từ đó xuống DbContext rồi xuống table
        //nó sẽ bị gọi bởi class GUI
        //nhưng nó sẽ gọi class repo cần khai báo biến repo
        public List<Book> GetAllBooks()
        {
            return _repo.GetAll();
        }
        public Book GetBookById(int id)
        {
            return _repo.Get(id);
        }

        public List<Book> SearchBooks(string keyword)
        {
            return _repo.Search(keyword);
        }

        public void AddBook(Book book)
        {
            _repo.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _repo.Update(book);
        }

        public void DeleteBook(Book book)
        {
            _repo.Delete(book);
        }
    }
}
