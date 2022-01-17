using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class Paket
    {

        public int Id { get; set; }

        public String Naziv { get; set; }

        public String Opis { get; set; }

        public int Cena { get; set; }

        public int Kategorija { get; set; }

        public int Uklonjen { get; set; }

    }
}
