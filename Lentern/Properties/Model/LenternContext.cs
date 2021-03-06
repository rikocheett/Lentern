﻿using System;

namespace Lentern.Model
{
    public class LenternContext : DbContext
    {
        public LenternContext() : base("DbCntext")
        { }

        public DbSet<Acc> Accs { get; set; }
        public DbSet<Intern> Interns { get; set; }
    }
}
