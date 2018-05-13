using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Models
{
    public interface IPublishers
    {
        string Name { get; set; }
        string Street { get; set; }
        int Street_number { get; set; }
        string City { get; set; }
        List<IBooks> PublisherBooks { get; set; }
    }
}
