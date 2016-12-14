using System;
using Microsoft.EntityFrameworkCore;
using ForgingAhead.Models;

namespace ForgingAhead.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base (options){}

		public DbSet<Character> Characters {get; set;}

		public DbSet<Equipment> Equipments {get; set;}

		public DbSet<EquipChar> EquipChars {get;set;}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EquipChar>()
				.HasKey(t => new {t.EquipmentId, t.CharacterId});

			modelBuilder.Entity<EquipChar>()
				.HasOne(eq => eq.Equipment)
				.WithMany(p => p.EquipChars)
				.HasForeignKey(eq => eq.EquipmentId);

			modelBuilder.Entity<EquipChar>()
				.HasOne(ch => ch.Character)
				.WithMany(p => p.EquipChars)
				.HasForeignKey(ch => ch.CharacterId);
		}
	}
}