using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSO_Hotelreservierung.Model
{
    internal class Kunde
    {
        public int Id { get; set; }
        public string Vorname { get; set; } = null!;
        public string Nachname { get; set; } = null!;
        public string Telefonnummer { get; set; } = null!;
        public string Adresse { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
