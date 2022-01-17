using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Praksa.Models
{
    public class Paket
    {

        public int id { get; set; }
        
        [Display(Name = "Naziv")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Naziv je obavezan")]
        public String Naziv { get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Opis je obavezan")]
        public String Opis { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Cena je obavezna")]
        public int Cena { get; set; }

        [Display(Name = "Kategorija(NET=1, IPTV=2, VOIP=3)")]
        [Range(1,3,ErrorMessage = "Kategorija mora biti 1, 2 ili 3")]
        [Required(ErrorMessage = "Kategorija je obavezna")]
        public int Kategorija { get; set; }

        public Paket()
        {

        }

        public readonly string[] kat = { "","Net", "Iptv", "Voip" };
        
    }
}
