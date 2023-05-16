using Library.UI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.Title);
            builder.Property(b => b.Pages);
            builder.Property(b => b.Category)
                .HasConversion<string>();
            builder.HasMany(a => a.Authors)
                .WithMany(b => b.Books);
        }
    }
}
