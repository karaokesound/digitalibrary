﻿using Library.UI.Model;
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
            builder.Property(b => b.BookId).ValueGeneratedOnAdd();
            builder.Property(b => b.Title);
            builder.Property(b => b.Copies);
            builder.Property(b => b.Category)
            .HasConversion<string>();
            builder.Property(b => b.Downloads);
            builder.Property(b => b.IsRented);
            builder.Property(b => b.AnyRequest);
            builder.Property(b => b.RequestUserId);

            // one-to-many relation
            builder.HasOne(a => a.Author)
                .WithMany(b => b.Books);

            builder.HasMany(c => c.Comments)
                .WithOne(b => b.Book);
        }
    }
}
