using System;

namespace WineCellar
{
    [Serializable]
    public class Wine
    {
        public string Name { set; get; }
        public int Year { set; get; }
        public string Country { set; get; }
        public decimal Volume { set; get; }
        public string Color { set; get; }
        public string Type { set; get; }
        public decimal Alcochol { set; get; }
        public int Amount { set; get; }
        public decimal Price { set; get; }
        public int Rack { set; get; }
        public int Shelf { set; get; }
        public Wine(string name, int year, string country, decimal volume, string color, string type, decimal alcochol, int amount, decimal price, int rack, int shelf)
        {
            this.Name = name;
            this.Year = year;
            this.Country = country;
            this.Volume = volume;
            this.Color = color;
            this.Type = type;
            this.Alcochol = alcochol;
            this.Amount = amount;
            this.Price = price;
            this.Rack = rack;
            this.Shelf = shelf;

        }

        public Wine()
        {
        }
    }
    }
