using System;
using System.Data.Entity;

namespace Lentern.Model
{
    public class LenternContext : DbContext
    {
        public LenternContext() : base("DBConnection")
        { }

        public DbSet<Acc> Accs { get; set; }
        public DbSet<Intern> Interns { get; set; }
    }
}
