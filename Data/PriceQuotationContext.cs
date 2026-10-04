using Microsoft.EntityFrameworkCore;
using Price_Quotation_App.Models;

namespace Price_Quotation_App.Data
{
    public class PriceQuotationContext : DbContext
    {
        public PriceQuotationContext(
            DbContextOptions<PriceQuotationContext> options)
            : base(options)
        {
        }

        public DbSet<PriceQuote> PriceQuotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PriceQuote>()
                .HasIndex(quote => quote.Slug)
                .IsUnique();

            modelBuilder.Entity<PriceQuote>().HasData(
                new PriceQuote
                {
                    Id = 1,
                    Slug = "quote-1",
                    Subtotal = 100m,
                    DiscountPercent = 10m,
                    DiscountAmount = 10m,
                    Total = 90m,
                    CreatedAtUtc = new DateTime(2025, 1, 1, 12, 0, 0, DateTimeKind.Utc)
                },
                new PriceQuote
                {
                    Id = 2,
                    Slug = "quote-2",
                    Subtotal = 250m,
                    DiscountPercent = 15m,
                    DiscountAmount = 37.50m,
                    Total = 212.50m,
                    CreatedAtUtc = new DateTime(2025, 1, 2, 12, 0, 0, DateTimeKind.Utc)
                });
        }
    }
}