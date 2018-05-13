using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.Models;

namespace Bookshop.Methods
{
    public class BooksManager : IBooksManager
    {
        public void AddBook(List<IBooks> List, IBooks book)
        {
            List.Add(book);
        }
        public void AddBook(List<IBooks> List, IBooks book, string name, string auth_name, string auth_surname, int year, int amount)
        {
            book.Name = name.First().ToString().ToUpper() + name.Substring(1);
            book.Auth_Name = auth_name.First().ToString().ToUpper() + auth_name.Substring(1);
            book.Auth_Surname = auth_surname.First().ToString().ToUpper() + auth_surname.Substring(1);
            book.Year = year;
            book.Amount = amount;
            List.Add(book);
        }

        public int GetAmount(IBooks book)
        {
            return book.Amount;
        }

        public void AddBookCopies (IBooks book, int amount)
        {
            if (amount < 0)
            {
                book.Amount -= amount;
            }
            else
            {
                book.Amount += amount;
            }
        }

        public void RemoveBookCopies (IBooks book, int amount)
        {
            if (amount < 0)
            {
                book.Amount += amount;
            }
            else
            {
                book.Amount -= amount;
            }

            if (book.Amount < 0)
            {
                book.Amount = 0;
                book.Avalible = false;
            }
        }

        public bool StartsWithUpper(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            char ch = str[0];
            return char.IsUpper(ch);
        }

    }
    
}
