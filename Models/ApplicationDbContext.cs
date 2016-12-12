using System;
using Microsoft.EntityFrameworkCore;
using ForgingAhead.Models;

namespace ForgingAhead.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Character> Characters {get; set;}

        public DbSet<Equipment> Equipments {get; set;}
    }
}