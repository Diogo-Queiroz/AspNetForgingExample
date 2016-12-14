using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForgingAhead.Models
{
    public class Character
    {
        [Key]
        public int ID {get; set;}
        public string Name {get; set;}
        [Display(Name="is Active")]
        public bool isActive {get; set;}
        public int Level {get; set;}
        public int Strength {get; set;}
        public int Dexterity {get; set;}
        public int Intelligence {get; set;}

        public List<EquipChar> EquipChars {get; set;}
    }
}