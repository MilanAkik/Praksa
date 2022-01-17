using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praksa.Models
{
    public class Izmena
    {

        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public String Stat { get; set; }
        public int Suma { get; set; }
        public int IdUgovor { get; set; }

        public Izmena()
        {

        }

    }
}
