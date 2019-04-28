using DockerNetCoreExample.Business.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNetCoreExample.Business
{
    public  class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) :
            base(options)
        { }

        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>()
                .HasKey(p => p.Id);
        }
    }
}
