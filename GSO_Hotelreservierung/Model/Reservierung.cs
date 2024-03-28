using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSO_Hotelreservierung.Model
{
    internal class Reservierung
    {
        public int Id { get; set; }
        public int Zimmer { get; set; }
        public int Kunde { get; set; }
        public string chechkInDatum { get; set; } = null!;
        public string checkOutDatum { get; set; } = null!;
    }
}
