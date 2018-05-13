using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookshop.API;
using Bookshop.Methods;
using Bookshop.Models;
using System.Collections.Generic;

namespace BookshopTest
{
    [TestClass]
    public class BookManTest
    {
        public List<IBooks> BookTemp;
        public List<IBooks> BookList;
        public List<IBooks> BookListSecond;

        BooksManager booksManager;
        PublisherManager publisherManager;
        BookshopAPI bookshopAPI;

        [TestInitialize]
        public void Initialize()
        {
            booksManager = new BooksManager();
            publisherManager = new PublisherManager();

            BookTemp = new List<IBooks>();
            BookList = new List<IBooks>();
            BookListSecond = new List<IBooks>();

            bookshopAPI = new BookshopAPI(booksManager, publisherManager, BookTemp);
        }

        [TestMethod]
        public void BookTitleStartsWithUpper()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 1992, 10));
            bool result = bookshopAPI.StartsWithUpper(BookList[0].Name);
            Assert.IsTrue(result, String.Format("Expected for '{0} : true; Actual: {1}",
                BookList[0].Name, result));
        }

        [TestMethod]
        public void AuthNameStartsWithUpper()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 1992, 10));

            bool result = bookshopAPI.StartsWithUpper(BookList[0].Auth_Name);
            Assert.IsTrue(result, String.Format("Expected for '{0} : true; Actual: {1}",
                BookList[0].Auth_Name, result));
        }

        [TestMethod]
        public void AuthSurnameStartsWithUpper()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 1992, 10));
            bool result = bookshopAPI.StartsWithUpper(BookList[0].Auth_Surname);
            Assert.IsTrue(result, String.Format("Expected for '{0} : true; Actual: {1}",
                BookList[0].Auth_Surname, result));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void AddBookWithWrongYear()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 2137, 20));
        }

        [TestMethod]
        public void CheckZeroAmountOfBook()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 2018, -15));
            int result = 0;
            Assert.AreEqual(booksManager.GetAmount(BookList[0]), result);
        }

        [TestMethod]
        public void AddCopiesOfBookWithPositiveNumber()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 2018, 20));
            bookshopAPI.AddBookCopies(BookList[0], 25);
            int result = 45;
            Assert.AreEqual(BookList[0].Amount, result);
        }

        [TestMethod]
        public void AddCopiesOfBookWithNegativeNumber()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 2018, 20));
            bookshopAPI.AddBookCopies(BookList[0], -13);
            int result = 33;
            Assert.AreEqual(BookList[0].Amount, result);
        }

        [TestMethod]
        public void RemoveCopiesOfBookWithPositiveNumber()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 2015, 36));
            bookshopAPI.RemoveBookCopies(BookList[0], 26);
            int result = 10;
            Assert.AreEqual(BookList[0].Amount, result);
        }

        [TestMethod]
        public void RemoveCopiesOfBookWithNegativeNumber()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 2015, 36));
            bookshopAPI.RemoveBookCopies(BookList[0], -26);
            int result = 10;
            Assert.AreEqual(BookList[0].Amount, result);
        }

        [TestMethod]
        public void RemoveCopiesOfBookWithException()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 2015, 36));
            bookshopAPI.RemoveBookCopies(BookList[0], 40);

            int result = 0;

            Assert.AreEqual(BookList[0].Amount, result);
        }

        [TestMethod]
        public void CompareTwoBookLists()
        {
            Books book = new Books("watykan", "jason", "pawel", 2015, 10);
            Books book2 = new Books("jak byc potezny", "łukasz", "stanisławowski", 2017, 13);

            BookList.Add(book);
            BookList.Add(book2);

            BookListSecond.Add(book);
            BookListSecond.Add(book2);

            CollectionAssert.AreEqual(BookList, BookListSecond);
        }

        [TestMethod]
        public void CompareTwoBookListsSecondMethod()
        {
            Books book = new Books();
            Books book2 = new Books();

            bookshopAPI.AddBook(BookList, book, "watykan", "jason", "pawel", 2015, 10);
            bookshopAPI.AddBook(BookList, book2, "watykano", "jasono", "pawelo", 2015, 10);

            booksManager.AddBook(BookListSecond, book, "watykano", "jasono", "pawelo", 2015, 10);
            booksManager.AddBook(BookListSecond, book2, "watykan", "jason", "pawel", 2015, 10);

            CollectionAssert.AreEqual(BookList, BookListSecond);
        }

        [TestMethod]
        public void SearchPatternInName()
        {
            Books book = new Books();
            Books book2 = new Books();
            Books book3 = new Books();

            booksManager.AddBook(BookList, book, "watykan", "jason", "pawel", 2015, 10);
            booksManager.AddBook(BookList, book2, "1984", "george", "orwell", 2011, 15);
            booksManager.AddBook(BookList, book3, "nice title", "kristof", "borewicz", 1913, 30);

            StringAssert.Contains(BookList[2].Name, "title");
        }

        [TestMethod]
        public void SearchPatternInAuthSurname()
        {
            Books book = new Books();

            bookshopAPI.AddBook(BookList, book, "nice title", "kristof", "borewicz", 1936, -19);

            StringAssert.EndsWith(BookList[0].Auth_Surname, "icz");
        }
    }
}
