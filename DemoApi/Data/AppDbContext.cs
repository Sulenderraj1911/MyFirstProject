using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DemoApi.Data
{
    public class AppDbContext:DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure the relationship between Book and Language
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Language)      // Book has one Language
                .WithMany(l => l.Books)       // Language has many Books
                .HasForeignKey(b => b.LanguageId); // Explicitly set LanguageId as FK


            modelBuilder.Entity<Currency>().HasData(
                new Currency(){ Id = 1, Title = "INR", Description = "Indian INR" },
                new Currency(){ Id = 2, Title = "Dollar", Description = "Dollar" },
                new Currency(){ Id = 3, Title = "Euro", Description = "Euro" },
                new Currency(){ Id = 4, Title = "Dinar", Description = "Dinar" }
            
            );
            modelBuilder.Entity<Language>().HasData(
              new Language() { LanguageId = 1, Title = "Hindi", Description = "Hindi" },
              new Language() { LanguageId = 2, Title = "Tamil", Description = "Tamil" },
              new Language() { LanguageId = 3, Title = "Punjabi", Description = "Punjabi" },
              new Language() { LanguageId = 4, Title = "Urdu", Description = "Urdu" }

          );
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<Currency> Currencies { get; set; }

    }
}
