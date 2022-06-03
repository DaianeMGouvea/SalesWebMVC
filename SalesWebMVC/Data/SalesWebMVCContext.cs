using System;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SalesWebMVCContext : DbContext
    {
        public SalesWebMVCContext (DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Departement>? Departement { get; set; }
        public DbSet<SallesRecord>? SallesRecord { get; set; }
        public DbSet<Seller>? Seller { get; set; }
    }
}
