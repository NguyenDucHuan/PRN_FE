using BookManagement.BLL.Services;
using BookManagement.DAL.Models;
using System.Windows;

namespace BookManagement_NguyenDucHuan
{
    /// <summary>
    /// Interaction logic for BookDetailWindow.xaml
    /// </summary>
    public partial class BookDetailWindow : Window
    {

        private BookCategoryService _bookCategoryService = new();
        private BookService _bookService = new();
        //bổ sung thêm 1 property SelectedBook full cũng được hoặc sort cũng được
        public Book SelectBook { get; set; } = null;
        //                                      món mới _selectedBook = null;
        // int yob;
        // yob = 2004; => set() thêm dấu = thì là set
        //cw(yob)  sout(yob) => get() thì không cần dấu = thì là get    

        //public BookDetail(Book book)
        //{
        //    InitializeComponent();
        //    _book = book;
        //}'
        public BookDetailWindow()
        {
            InitializeComponent();
        }



        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // đổ vào combobox treo đầu dê bán thịt bò
            BookCategoryIdComboBox.ItemsSource = _bookCategoryService.GetAllCategory();
            BookCategoryIdComboBox.DisplayMemberPath = "BookGenreType";
            BookCategoryIdComboBox.SelectedValuePath = "BookCategoryId";
            if (SelectBook != null)
            {
                //nếu chế độ update đổi lable
                BookModeLabel.Content = "Update Book";
                //đổ data vào các ô text
                //Lưu ý Disable BookIdTextBox, không cho edit PK - Toang PK nếu có - hoặc chơi Cascade

                BookModeLabel.Content = SelectBook.BookId.ToString();
                BookIdTextBox.IsEnabled = false;
                //chuỗi            =  kiểu số cần convert về chuỗi
                BookNameTextBox.Text = SelectBook.BookName;
                DescriptionTextBox.Text = SelectBook.Description;
                AuthorTextBox.Text = SelectBook.Author;
                PublicationDateDatePicker.Text = SelectBook.PublicationDate.ToString();
                QuantityTextBox.Text = SelectBook.Quantity.ToString();
                PriceTextBox.Text = SelectBook.Price.ToString();
                //thực ra cái combo box đã đổ sẵn 5 loại sách rồi
                //chỉ cần chờ ai đó select ta chủ động select ứng với cate của cuốn sách đấy
            }
            else
            {
                BookModeLabel.Content = "Create Book";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectBook == null)
            {
                AddBook();
            }
            else
            {
                UpdateBook();
            }
        }
        private void UpdateBook()
        {
            if (BookNameTextBox.Text.Length < 5 || BookNameTextBox.Text.Length > 90)
            {
                MessageBox.Show("BookName must be between 5 and 90 characters");
                return;
            }
            if (!char.IsUpper(BookNameTextBox.Text[0]) || BookNameTextBox.Text.Skip(1).Any(char.IsUpper))
            {
                MessageBox.Show("BookName must start with a capital letter and only the first letter can be uppercase");
                return;
            }
            if (double.Parse(PriceTextBox.Text) < 0 || int.Parse(PriceTextBox.Text) > 4000000)
            {
                MessageBox.Show("Quantity must be between 0 and 4000000");
                return;
            }
            if (int.Parse(QuantityTextBox.Text) < 0 || int.Parse(QuantityTextBox.Text) > 4000000)
            {
                MessageBox.Show("Quantity must be between 0 and 4000000");
                return;
            }
            SelectBook.BookName = BookNameTextBox.Text;
            SelectBook.Description = QuantityTextBox.Text;
            SelectBook.Author = QuantityTextBox.Text;
            SelectBook.PublicationDate = DateTime.Parse(PublicationDateDatePicker.Text);
            SelectBook.Quantity = int.Parse(QuantityTextBox.Text);
            SelectBook.Price = double.Parse(PriceTextBox.Text);
            SelectBook.BookCategoryId = int.Parse(BookCategoryIdComboBox.SelectedValue.ToString());
            _bookService.UpdateBook(SelectBook);
        }
        private void AddBook()
        {
            if (BookNameTextBox.Text.Length < 5 || BookNameTextBox.Text.Length > 90)
            {
                MessageBox.Show("BookName must be between 5 and 90 characters");
                return;
            }
            if (!char.IsUpper(BookNameTextBox.Text[0]) || BookNameTextBox.Text.Skip(1).Any(char.IsUpper))
            {
                MessageBox.Show("BookName must start with a capital letter and only the first letter can be uppercase");
                return;
            }
            if (double.Parse(PriceTextBox.Text) < 0 || int.Parse(PriceTextBox.Text) > 4000000)
            {
                MessageBox.Show("Quantity must be between 0 and 4000000");
                return;
            }
            if (int.Parse(QuantityTextBox.Text) < 0 || int.Parse(QuantityTextBox.Text) > 4000000)
            {
                MessageBox.Show("Quantity must be between 0 and 4000000");
                return;
            }
            Book book = new Book()
            {
                BookId = int.Parse(BookIdTextBox.Text),
                BookName = BookNameTextBox.Text,
                Description = DescriptionTextBox.Text,
                Author = AuthorTextBox.Text,
                PublicationDate = DateTime.Parse(PublicationDateDatePicker.Text),
                Quantity = int.Parse(QuantityTextBox.Text),
                Price = double.Parse(PriceTextBox.Text),
                BookCategoryId = int.Parse(BookCategoryIdComboBox.SelectedValue.ToString())
            };
            _bookService.AddBook(book);
        }
    }
}
