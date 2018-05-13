using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bookshop.Models;
using Bookshop.Methods;

namespace BookshopTest
{
    [TestClass]
    public class CSVTest
    {

        public List<Books> BookList = new List<Books>();
        public List<Books> BookListSecond = new List<Books>();

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential),
            DeploymentItem("data.csv")]

        public void CompareTwoBookListsDDUT()
        {
            BookList.Add(new Books("watykan", "jason", "pawulenko", 1992, 10));

            string name = TestContext.DataRow["Name"].ToString();
            string auth_name = TestContext.DataRow["Auth_Name"].ToString();
            string auth_surname = TestContext.DataRow["Auth_Surname"].ToString();
            int year = Int32.Parse(TestContext.DataRow["Year"].ToString());
            int amount = Int32.Parse(TestContext.DataRow["Amount"].ToString());

            BookListSecond.Add(new Books(name, auth_name, auth_surname, year, amount));

            Assert.AreEqual(BookList[0].Name, BookListSecond[0].Name);
        }
    }
}
