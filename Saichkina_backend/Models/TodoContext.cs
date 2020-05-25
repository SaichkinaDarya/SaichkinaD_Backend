using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Saichkina_backend.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
               : base(options)
        {
        }
        public DbSet<Doloto> Dolotoes { get; set; }
        public DbSet<Сharacteristic> Characteristics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doloto>()
                .OwnsMany(property => property.Totaldolotoes);
        }
        public IEnumerable<Doloto> GetPlotnichiyDoloto(IEnumerable<Doloto> doloto)
        {
            return doloto.Where(p => p.Kind == "threeCone");
        }
    }
}
