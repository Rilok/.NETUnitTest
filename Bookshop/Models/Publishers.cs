using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Models
{
    public class Publishers : IPublishers
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public int Street_number { get; set; }
        public string City { get; set; }
        public List<IBooks> PublisherBooks { get; set; }
        public Publishers()
        {
            PublisherBooks = new List<IBooks>();
        }
        public Publishers (string name, string street, int street_number, string city)
        {
            Name = name.First().ToString().ToUpper() + name.Substring(1);
            Street = street.First().ToString().ToUpper() + street.Substring(1);
            if (street_number < 1)
                throw new ArgumentOutOfRangeException("Nieodpowiedni numer ulicy");
            else
                Street_number = street_number;
            City = city.First().ToString().ToUpper() + city.Substring(1);
            PublisherBooks = new List<IBooks>();
        }
    }
}
