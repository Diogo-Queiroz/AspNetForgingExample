using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForgingAhead.Models
{
    public class Equipment
    {
        [Key]
        public int ID {get; set;}
        public string Name {get; set;}
        public int Preco {get; set;}
        public string Tipo {get; set;}
    }
}