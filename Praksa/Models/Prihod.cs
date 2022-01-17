using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Praksa.Models
{
    public class Prihod
    {
        [Display(Name = "Broj ugovora")]
        public String id { get; set; }

        [Display(Name = "Prihod (RSD)")]
        public int prihod { get; set; }

        public Prihod()
        {

        }

    }
}
