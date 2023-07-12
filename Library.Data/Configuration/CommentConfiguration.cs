using Library.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Library.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentModel>
    {
        public void Configure(EntityTypeBuilder<CommentModel> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(c => c.CommentId);
            builder.Property(c => c.CommentId);
            builder.Property(c => c.Text);

            // one-to-many relation
            builder.HasOne(b => b.Book)
                .WithMany(c => c.Comments);
        }
    }
}
