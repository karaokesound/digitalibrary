using Library.UI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<AuthorModel>
    {
        public void Configure(EntityTypeBuilder<AuthorModel> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(a => a.AuthorId);
            builder.Property(a => a.FirstName);
            builder.Property(a => a.LastName);

            builder.HasMany(b => b.Books)
                .WithMany(a => a.Authors);
        }
    }
}
