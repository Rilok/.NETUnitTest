using System;
using Bookshop.API;
using Bookshop.Models;
using Bookshop.Methods;
using Bookshop.Models.Fakes;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookshopTest
{
    [TestClass]
    public class StubTest
    {
        BooksManager booksManager;
        PublisherManager publisherManager;
        public List<IBooks> books;

        BookshopAPI bookshopAPI;

        [TestInitialize]
        public void Initialize()
        {
            booksManager = new BooksManager();
            publisherManager = new PublisherManager();
            books = new List<IBooks>();

            bookshopAPI = new BookshopAPI(booksManager, publisherManager, books);
        }

        [TestMethod]
        public void AddBookUsingStub()
        {
            var book = new StubIBooks()
            {
                NameGet = () => "Higurashi",
                NameGetAuth = () => "Jon",
                SurnameGetAuth = () => "Dzony",
                YearGet = () => 1992,
                AmountGet = () => 30,
                AvalibleGet = () => true
            };

            bookshopAPI.AddBook(books, book);

            Assert.AreEqual(books[0].Name, "Higurashi");
        }
    }
}
