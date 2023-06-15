using Library.Data.Configuration;
using Library.Data.Configuration.many_to_many;
using Library.Models.Model;
using Library.Models.Model.many_to_many;
using Library.UI.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<AccountModel> Users { get; set; }
        public DbSet<LanguageModel> Languages { get; set; }
        public DbSet<GradeModel> Grades { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<BookLanguageModel> BookLanguages { get; set; }
        public DbSet<AccountBookModel> AccountBooks { get; set; }
        public DbSet<BookGradeModel> BookGrades { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DigitalLibraryDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LanguageConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GradeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookLanguageConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountBookConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookGradeConfiguration).Assembly);
        }
    }
}
