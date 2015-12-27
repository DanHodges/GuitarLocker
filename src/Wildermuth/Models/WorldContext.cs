using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace GuitarLocker.Models
{
    public class GuitarLockerContext : IdentityDbContext<GuitarLockerUser>
    {
        public GuitarLockerContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<SoundClip> SoundClips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:GuitarLockerContextConnection"];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder); 
        }
    }
}
