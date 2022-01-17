using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praksa.Models
{
    public class UgovorIspis
    {

        public int Id { get; set; }
        public String KIme { get; set; }
        public int Trajanje { get; set; }
        public DateTime Kreirano { get; set; }

        public UgovorIspis()
        {

        }

    }
}
