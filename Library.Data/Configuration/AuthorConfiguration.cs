using Library.UI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<AuthorModel>
    {
        public void Configure(EntityTypeBuilder<AuthorModel> builder)
        {
            builder.HasKey(author => author.AuthorId);

            builder.Property(author => author.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("First_name");

            builder.Property(author => author.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Last_name");

            builder.Property(author => author.AuthorBook)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Books");
        }
    }
}
