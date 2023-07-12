using Library.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class BookLanguageConfiguration : IEntityTypeConfiguration<BookLanguageModel>
    {
        public void Configure(EntityTypeBuilder<BookLanguageModel> builder)
        {
            builder.ToTable("BooksLanguages");
            builder.HasKey(bl => new { bl.BookId, bl.LanguageId });

            builder.HasOne(bl => bl.Book)
                .WithMany(b => b.BookLanguages)
                .HasForeignKey(bl => bl.BookId);

            builder.HasOne(bl => bl.Language)
                .WithMany(l => l.BookLanguages)
                .HasForeignKey(bl => bl.LanguageId);
        }
    }
}
