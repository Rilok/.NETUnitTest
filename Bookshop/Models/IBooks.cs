using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Models
{
    public interface IBooks
    {
        string Name { get; set; }
        string Auth_Name { get; set; }
        string Auth_Surname { get; set; }
        int Year { get; set; }
        int Amount { get; set; }
        bool Avalible { get; set; }
    }
}
