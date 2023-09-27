using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace LibraBase
{
    class User
    {
        public User(int id, string? name, string? fаmily)
        {
            this.id = id;
            this.name = name;
            this.Family = fаmily;
            this.Books = new List<Book>();
        }
        public int id { get; set; }
        public string? name { get; set; }
        public string? Family { get; set;}
        public List<Book> Books { get; set; }


        public void BorrowBook(Book book)
        {
            if (book.Count > 0)
            {
                Books.Add(book);
                book.Count--;
            }
            else
            {
                MessageBox.Show("книга кончилась");
            }
        }

        public void ReturnBook(Book book)
        {
            if (Books.Contains(book))
            {
                Books.Remove(book);
                book.Count++;
            }
            else
            {
                MessageBox.Show("книга возвращена");
            }
        }
    }
}
