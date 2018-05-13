using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.Models;

namespace Bookshop.Methods
{
    public class PublisherManager : IPublisherManager
    {
        public void AddPublisher(List<IPublishers> PubList, 
            IPublishers publisher, string name, string street,
            int street_number, string city, List<IBooks> booksList)
        {
            publisher.Name = name.First().ToString().ToUpper() + name.Substring(1);
            publisher.Street = street.First().ToString().ToUpper() + name.Substring(1);
            if (street_number < 1)
                throw new ArgumentOutOfRangeException("Nieprawidłowy numer ulicy");
            else
                publisher.Street_number = street_number;
            publisher.City = city.First().ToString().ToUpper() + name.Substring(1);
            publisher.PublisherBooks = booksList;
            PubList.Add(publisher);
        }

        public void RemovePublisher(List<IPublishers> PubList,
            string name)
        {
            IPublishers temp = PubList.Find(x => x.Name == name);
            PubList.Remove(temp);
        }

        public void AddBookToPublisher(List<IPublishers> PubList,
            IBooks book, string publisherName, string name, string auth_name, string auth_surname, 
            int year, int amount)
        {
            book.Name = name.First().ToString().ToUpper() + name.Substring(1);
            book.Auth_Name = auth_name.First().ToString().ToUpper() + auth_name.Substring(1);
            book.Auth_Surname = auth_surname.First().ToString().ToUpper() + auth_surname.Substring(1);
            if (year < 1900 || year > 2018)
                throw new ArgumentOutOfRangeException("Nieprawidłowy rok");
            else
                book.Year = year;
            if (amount <= 0)
            {
                book.Amount = 0;
                book.Avalible = false;
            }
            else
            {
                book.Amount = amount;
                book.Avalible = true;
            }
            IPublishers temp = PubList.Find(x => x.Name == publisherName);
            temp.PublisherBooks.Add(book);
        }
        
        public void AddBookToPublisher(List<IPublishers> PubList, IBooks book,
            string publisherName)
        {
            IPublishers temp = PubList.Find(x => x.Name == publisherName);
            temp.PublisherBooks.Add(book);
        }
        public void RemoveBookFromPublisher(List<IPublishers> PubList,
            string publisherName, string bookToDel)
        {
            IPublishers temp = PubList.Find(x => x.Name == publisherName);
            IBooks del = temp.PublisherBooks.Find(x => x.Name == bookToDel);

            temp.PublisherBooks.Remove(del);
        }
    }
}
