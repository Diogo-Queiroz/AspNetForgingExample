using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForgingAhead.Models
{
	public class EquipChar
	{
		public int EquipmentId {get;set;}
		public Equipment Equipment {get;set;}

		public int CharacterId {get;set;}
		public Character Character {get;set;}

		public bool IsEquiped {get;set;}
	}
}