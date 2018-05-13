using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookshop.Methods;
using Bookshop.Models;
using Bookshop.API;
using System.Collections.Generic;


namespace BookshopTest
{
    [TestClass]
    public class PubManTest
    {
        public List<IBooks> BookList = new List<IBooks>();
        public List<IBooks> BookListSecond = new List<IBooks>();

        public List<IBooks> BookTemp;

        public List<IPublishers> PublisherList = new List<IPublishers>();
        public List<IPublishers> PublisherListSecond = new List<IPublishers>();

        BooksManager booksManager;
        PublisherManager publisherManager;
        BookshopAPI bookshopAPI;

        [TestInitialize]
        public void Initialize()
        {
            booksManager = new BooksManager();
            publisherManager = new PublisherManager();
            BookTemp = new List<IBooks>();

            bookshopAPI = new BookshopAPI(booksManager, publisherManager, BookTemp);
        }

        [TestMethod]
        public void CompareTwoPublishers()
        {
            Publishers publisher = new Publishers();
            Publishers publisherSecond = new Publishers();

            bookshopAPI.AddPublisher(PublisherList, publisher, "PWN", "Orzechowa", 13, "Wielka góra", BookList);
            bookshopAPI.AddPublisher(PublisherListSecond, publisherSecond, "PWN", "Orzechowa", 13, "Wielka góra", BookList);

            CollectionAssert.AreNotEqual(PublisherList, PublisherListSecond);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPublisherWithWrongStreetNumber()
        {
            Publishers publisher = new Publishers();
            bookshopAPI.AddPublisher(PublisherList, publisher, "waneko", "podkarpacka", -13, "bialystok", BookList);
        }

        [TestMethod]
        public void CheckIfBookIsAddedToPublisher()
        {
            Publishers pub = new Publishers("waneko", "podkarpacka", 21, "bialystok");
            List<Books> pubBooks = new List<Books>();
            //Books smth = new Books();
            PublisherList.Add(pub);
            Books smth = new Books("higurashi", "jon", "nazuki", 2015, 30);
            //PublisherManager.AddBookToPublisher(PublisherList, smth, "waneko", "higurashi", "jon", "nazuki", 2015, 30);
            bookshopAPI.AddBookToPublisher(PublisherList, smth, "Waneko");
            string name = "higurashi";

            Assert.AreEqual(PublisherList[0].PublisherBooks[0].Name.ToString().ToLower(), name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CheckIfBookIsDeletedFromPublisherBookList()
        {
            Publishers pub = new Publishers("waneko", "podkarpacka", 13, "zielona gora");
            Books smth = new Books("higurashi", "jon", "nazuki", 2015, 30);
            List<IBooks> pubBooks = new List<IBooks>();
            pubBooks.Add(smth);
            pub.PublisherBooks = pubBooks;

            bookshopAPI.RemoveBookFromPublisher(PublisherList, "Waneko", "Higurashi");

            Console.WriteLine(PublisherList[0].PublisherBooks[0].Name);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfPublisherIsDeleted()
        {
            Publishers pub = new Publishers("waneko", "podkarpacka", 13, "zielona gora");
            PublisherList.Add(pub);

            bookshopAPI.RemovePublisher(PublisherList, "Waneko");

            Console.Write(PublisherList[0].Name);
        }

        [TestMethod]
        public void SearchPatternInPublisherBooksName()
        {
            Publishers pub = new Publishers();

            Books smth = new Books("higurashi", "jon", "nazuki", 2015, 30);

            bookshopAPI.AddPublisher(PublisherList, pub, "waneko", "podkarpacka", 21, "bialystok", BookList);
            bookshopAPI.AddBookToPublisher(PublisherList, smth, "Waneko");

            StringAssert.Contains(PublisherList[0].PublisherBooks[0].Auth_Name.ToLower(), "jon");
        }
    }
}
