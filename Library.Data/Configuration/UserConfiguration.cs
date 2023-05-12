using Library.UI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Username)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("Username");

            builder.Property(user => user.Password)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("Password");

            builder.Property(user => user.FirstName)
                .HasMaxLength(25)
                .HasColumnName("First_name");

            builder.Property(user => user.LastName)
                .HasMaxLength(25)
                .HasColumnName("Last_name");

            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("Email");

            builder.Property(user => user.City)
                .HasMaxLength(25)
                .HasColumnName("City");

            builder.Property(user => user.Library)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("City");
        }
    }
}
