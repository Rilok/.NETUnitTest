using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.Models;


namespace Bookshop.Methods
{
    public interface IPublisherManager
    {
        void AddPublisher(List<IPublishers> PubList, IPublishers publisher,
            string name, string street, int street_number, string city, 
            List<IBooks> booksList);

        void RemovePublisher(List<IPublishers> PubList, string name);

        void AddBookToPublisher(List<IPublishers> PubList, IBooks book,
            string publisherName, string name, string auth_name,
            string auth_surname, int year, int amount);

        void AddBookToPublisher(List<IPublishers> PubList, IBooks book,
            string publisherName);

        void RemoveBookFromPublisher(List<IPublishers> PubList,
            string publisherName, string bookToDel);
    }
}
