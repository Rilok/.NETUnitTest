using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.Models;


namespace Bookshop.Methods
{
    public interface IBooksManager
    {
        void AddBook(List<IBooks> List, IBooks book);

        void AddBook(List<IBooks> List, IBooks book, string name, string auth_name,
            string auth_surname, int year, int amount);

        int GetAmount(IBooks book);

        void AddBookCopies(IBooks book, int amount);

        void RemoveBookCopies(IBooks book, int amount);

        bool StartsWithUpper(string str);
    }
}
