using DisneyData.Models;
using Microsoft.EntityFrameworkCore;

namespace DisneyData
{
    public class DisneyDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Disney;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .Property(x => x.Image)
                .IsRequired(false);

            modelBuilder.Entity<Genre>()
                .Property(x => x.Image)
                .IsRequired(false);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Image)
                .IsRequired(false);

            modelBuilder.Entity<Genre>().HasData(
                   new Genre { ID = 1, Name = "Romantic" });
            modelBuilder.Entity<Genre>().HasData(
                   new Genre { ID = 2, Name = "Infantil" });
            modelBuilder.Entity<Genre>().HasData(
                   new Genre { ID = 3, Name = "Terror" });
            modelBuilder.Entity<Movie>().HasData(
                    new Movie { ID = 1, Title = "The Notebook", CreationDate = DateTime.Parse("2000-01-10"), Score = 5, GenreID =1 });
            modelBuilder.Entity<Movie>().HasData(
                    new Movie { ID = 2, Title = "Shrek", CreationDate = DateTime.Parse("2008-06-20"), Score = 5, GenreID = 2 });
            modelBuilder.Entity<Movie>().HasData(
                    new Movie { ID = 3, Title = "It", CreationDate = DateTime.Parse("2016-05-10"), Score = 2, GenreID = 3 });            
            modelBuilder.Entity<Character>().HasData(
                    new Character { ID = 1, Name = "Rachel McAdams", Age = 30, Weight = 60 , History="Two young in love." , MovieID=1 });
        }
    }
}