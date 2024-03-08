using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CrudMVCCodeFirst.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrudMVCCodeFirst.Data
{
    public class LaunchContext : DbContext
    {
        public LaunchContext() : base("LaunchContext")
        {
        }

        public DbSet<LaunchEntry> Launches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}