using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Praksa.Models
{
    public class Aktivni
    {
        [Display(Name = "Trenutno aktivnih ugovora")]
        public int aktivni { get; set; }

        [Display(Name = "Trenutno neaktivnih ugovora")]
        public int neaktivni { get; set; }

        public Aktivni()
        {

        }

    }
}
