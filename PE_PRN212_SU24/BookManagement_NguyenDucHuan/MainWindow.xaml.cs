using BookManagement.BLL.Services;
using BookManagement.DAL.Models;
using System.Windows;

namespace BookManagement_NguyenDucHuan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookService _service = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        public UserAccount User { get; set; }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BookMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
        // tach code giup cho viet tuong tac de dang
        // update thi load lai trang 
        // delete load lai trang
        // new cx load lai trang
        // ham nay dc dung o nhieu noi , goi laf HELPER, PRiVATE la du

        private void LoadDataGrid()
        {
            if (User.Role == 2)
            {
                CreateButton.Opacity = 0;
                UpdateButton.Opacity = 0;
                DeleteButton.Opacity = 0;
            }
            HelloMessageLabel.Content = "Hello, " + User.FullName;
            BookListDataGrid.ItemsSource = null; // xoa di cai cu tai lai
            BookListDataGrid.ItemsSource = _service.GetAllBooks();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string keyword = BookNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            if (!string.IsNullOrEmpty(keyword))
            {
                BookListDataGrid.ItemsSource = null;
                BookListDataGrid.ItemsSource = _service.SearchBooks(keyword);
                return;
            }
            else if (!string.IsNullOrEmpty(description))
            {
                BookListDataGrid.ItemsSource = null;
                BookListDataGrid.ItemsSource = _service.SearchBooks(description);
                return;
            }


        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //lấy cuốn sách user chọn từ lưới để đẩy sang detail
            //không lấy từ table
            //Book selected = (Book)BookListDataGrid.SelectedItem;
            //bị exception nếu k ép được ví dụ k chọn dòng nào
            //bắt excetion hoặc if else
            //Book selectedBook = BookListDataGrid.SelectedItem as Book;
            //as ép vế trái thành vế phải nếu k thành công thì gán null thay vì quăng exception
            //if (selectedBook == null)
            //{
            //    MessageBox.Show("Please select a book to update", "Choose one", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}
            if (BookListDataGrid.SelectedItem is Book selectedBook)
            {
                //tìm cách đẩy selectedBook sang BookDetail
                //không xuông db lấy lại
                BookDetailWindow bookDetail = new();
                //đẩy cuốn sách sang bên kia
                bookDetail.SelectBook = selectedBook;
                bookDetail.ShowDialog();
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Please select a book to update");
            }

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (BookListDataGrid.SelectedItem is Book selectedBook)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this book?", "Delete Book", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _service.DeleteBook(selectedBook);
                    LoadDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete");
            }
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            BookDetailWindow bookDetailWindow = new();
            bookDetailWindow.ShowDialog();
            LoadDataGrid();

        }
    }
}