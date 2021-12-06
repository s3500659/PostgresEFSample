using Microsoft.EntityFrameworkCore;
using PostgresEF.Models;
using PostgresEF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresEF.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductInvoice>()
                .HasKey(pi => new {pi.ProductId, pi.InvoiceId});

            modelBuilder.Entity<ProductInvoice>()
                .HasOne(pi => pi.Product)
                .WithMany(i => i.ProductInvoices)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<ProductInvoice>()
                .HasOne(i => i.Invoice)
                .WithMany(pi => pi.ProductInvoices)
                .HasForeignKey(i => i.InvoiceId);

      
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProductInvoice> ProductInvoices { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
    }
}