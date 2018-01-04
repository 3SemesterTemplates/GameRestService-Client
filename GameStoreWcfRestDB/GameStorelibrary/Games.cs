using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStorelibrary
{
    public class Games
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int AntalPåLager { get; set; }

        public Games()
        {

        }

        public Games(int id, string title, double price, int antalPåLager)
        {
            Id = id;
            Title = title;
            Price = price;
            AntalPåLager = antalPåLager;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(Price)}: {Price}, {nameof(AntalPåLager)}: {AntalPåLager}";
        }
    }
}
