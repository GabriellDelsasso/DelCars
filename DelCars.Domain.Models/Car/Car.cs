using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelCars.Domain.Models.Car
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public bool Rented { get; set; } = false;
        public DateTime ReturnDate { get; set; }
    }
}
