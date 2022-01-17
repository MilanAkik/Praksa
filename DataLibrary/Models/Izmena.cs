using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class Izmena
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int Stat { get; set; }
        public int Suma { get; set; }
        public int IdUgovor { get; set; }

        public Izmena()
        {

        }
    }
}
