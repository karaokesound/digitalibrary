using Library.UI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.HasKey(book => book.BookId);

            builder.Property(book => book.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Title");

            builder.Property(book => book.AuthorBook)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Author");

            builder.Property(book => book.Pages)
                .HasMaxLength(5)
                .HasColumnName("Pages");
        }
    }
}
