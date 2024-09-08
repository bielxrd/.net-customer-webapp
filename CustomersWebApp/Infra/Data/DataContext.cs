using CustomersWebApp.Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace CustomersWebApp.Infra.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Email> Emails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Address>().ToTable("Addresses");
        modelBuilder.Entity<Email>().ToTable("Emails");


        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Addresses)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Emails)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Customer>()
            .Property(c => c.Id)
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<Address>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Address>()
            .Property(c => c.Id)
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<Email>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Email>()
            .Property(c => c.Id)
            .HasDefaultValueSql("NEWID()");


    }

}
