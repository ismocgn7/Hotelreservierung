using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSO_Hotelreservierung.Model
{
    internal class ZimmerKategorie
    {
        public int Id { get; set; }
        public string Kategorie { get; set; } = null!;
        public decimal Preis { get; set; }
        public string Beschreibung { get; set; } = null!;
    }
}
