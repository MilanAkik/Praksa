using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class Ugovor
    {
        public int Id { get; set; }
        public String KIme { get; set; }
        public int Trajanje { get; set; }
        public int Popust { get; set; }
        public int Gratis { get; set; }
        public int Stat { get; set; }
        public DateTime Kreirano { get; set; }
        public int? Net { get; set; }
        public int? Iptv { get; set; }
        public int? Voip { get; set; }

        public Ugovor()
        {

        }
    }
}
