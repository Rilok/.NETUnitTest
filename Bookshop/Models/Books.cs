using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Models
{
    public class Books : IBooks
    {
        public string Name { get; set; }
        public string Auth_Name { get; set; }
        public string Auth_Surname { get; set; }
        public int Year { get; set; }
        public int Amount { get; set; }
        public bool Avalible { get; set; }
        public Books()
        {

        }
        public Books (string name, string auth_name, string auth_surname, int year, int amount)
        {
            Name = name.First().ToString().ToUpper() + name.Substring(1);
            Auth_Name = auth_name.First().ToString().ToUpper() + auth_name.Substring(1);
            Auth_Surname = auth_surname.First().ToString().ToUpper() + auth_surname.Substring(1);
            if (year <= 2018 && year >= 1900)
                Year = year;
            else
                throw new ArgumentOutOfRangeException("Rok nie mieści się w przedziale.");
            if (amount <= 0)
            {
                Amount = 0;
                Avalible = false;
            }
            else
            {
                Amount = amount;
                Avalible = true;
            }
        }
    }
}
