using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> Books = new List<Book>();

        public MainWindow()
        {
            int index = 0;
            InitializeComponent();

            List<User> users = new List<User>()
            {
                new User(1, "A", "A"),
                new User(2, "B", "B"),
            };
            UserList.ItemsSource = users;
            UserList.FontSize = 10;
            List<Book> books = new List<Book>()
            {
                new Book("Author1", 1, 1999, 1, 27, 5),
                new Book("Author2", 2, 1929, 1, 27, 2),
            };
            BookList.ItemsSource = books;
            BookList.FontSize = 10;


            users[0].BorrowBook(books[0]);
            users[0].BorrowBook(books[0]);
            users[0].BorrowBook(books[1]);
            users[1].BorrowBook(books[0]);
            users[1].BorrowBook(books[1]);
            List<Book> allBooks = new List<Book>();

            foreach (var user in users)
            {
                allBooks.AddRange(user.Books);
            }
            BookSelector.ItemsSource =  BookUserList.ItemsSource = allBooks;
            UserSelector.ItemsSource = users;
        }
        private void AddSelectedBook(object sender, RoutedEventArgs e)
        {
            AddBookUser();
        }

        private void AddBookUser()
        {
            User selectedUser = (User)UserSelector.SelectedItem;
            Book selectedBook = (Book)BookSelector.SelectedItem;
            //безумие(повторяются объекты)
            if (selectedUser != null && selectedBook != null)
            {
                selectedUser.BorrowBook(selectedBook);
                UpdateBookList();
            }
            else
            {
                MessageBox.Show("Выберите пользователя и книгу");
            }
        }
        private void UpdateBookList()
        {
            List<Book> allBooks = new List<Book>();
            foreach (var user in (UserList.ItemsSource as List<User>)!)
            {
                allBooks.AddRange(user.Books);
            }
            BookUserList.ItemsSource = allBooks;
        }
    }
}
