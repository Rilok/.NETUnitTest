using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.Methods;
using Bookshop.Models;


namespace Bookshop.API
{
    public class BookshopAPI
    {
        private readonly IBooksManager _booksManager;
        private readonly IPublisherManager _publisherManager;

        private List<IBooks> _books;

        public BookshopAPI (IBooksManager booksManager, IPublisherManager publisherManager, 
            List<IBooks> books)
        {
            _booksManager = booksManager;
            _publisherManager = publisherManager;
            _books = books;
        }

        public void AddBook(List<IBooks> List, IBooks book)
        {
            _booksManager.AddBook(List, book);
        }

        public void AddBook(List<IBooks> List, IBooks book, string name, 
            string auth_name, string auth_surname, int year, int amount)
        {
            _booksManager.AddBook(List, book, name, auth_name, auth_surname,
                year, amount);
        }

        public int GetAmount(IBooks book)
        {
            return _booksManager.GetAmount(book);
        }

        public void AddBookCopies(IBooks book, int amount)
        {
            _booksManager.AddBookCopies(book, amount);
        }

        public void RemoveBookCopies(IBooks book, int amount)
        {
            _booksManager.RemoveBookCopies(book, amount);
        }

        public bool StartsWithUpper(string str)
        {
            return _booksManager.StartsWithUpper(str);
        }

        public void AddPublisher(List<IPublishers> PubList, IPublishers publisher, 
            string name, string street, int street_number, string city, 
            List<IBooks> booksList)
        {
            _publisherManager.AddPublisher(PubList, publisher, name, street,
                street_number, city, booksList);
        }

        public void RemovePublisher(List<IPublishers> PubList, string name)
        {
            _publisherManager.RemovePublisher(PubList, name);
        }

        public void AddBookToPublisher(List<IPublishers> PubList, IBooks book, 
            string publisherName, string name, string auth_name, string auth_surname, 
            int year, int amount)
        {
            _publisherManager.AddBookToPublisher(PubList, book, publisherName,
                name, auth_name, auth_surname, year, amount);
        }

        public void AddBookToPublisher(List<IPublishers> PubList, IBooks book, 
            string publisherName)
        {
            _publisherManager.AddBookToPublisher(PubList, book, publisherName);
        }

        public void RemoveBookFromPublisher(List<IPublishers> PubList, 
            string publisherName, string bookToDel)
        {
            _publisherManager.RemoveBookFromPublisher(PubList, publisherName, bookToDel);
        }
    }
}
