using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Praksa.Models
{
    public class Ugovor
    {

        [Display(Name = "Broj Ugovora")]
        [Required(ErrorMessage = "Broj ugovora je obavezan")]
        public int Id { get; set; }

        [Display(Name = "Korisnicko ime")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Korisnicko ime je obavezno")]
        public String KIme { get; set; }

        [Display(Name = "Trajanje (12/24 meseci)")]
        [RegularExpression(@"^(12|24)$")]
        [Required(ErrorMessage = "Trajanje je obavezno")]
        public int Trajanje { get; set; }

        [Display(Name = "Popust")]
        [Range(0,100,ErrorMessage ="Granice popusta su 0-100")]
        [Required(ErrorMessage = "Popust je obavezan")]
        public int Popust { get; set; }

        [Display(Name = "Gratis period")]
        [Range(1, 6, ErrorMessage = "Granice gratisa su 1-6")]
        [Required(ErrorMessage = "Gratis je obavezan")]
        public int Gratis { get; set; }

        public int? Net { get; set; }

        public int? Iptv { get; set; }

        public int? Voip { get; set; }

        public int Stat { get; set; }

        public Ugovor()
        {

        }

    }
}
