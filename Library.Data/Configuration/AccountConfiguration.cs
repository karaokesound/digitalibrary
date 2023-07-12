using Library.UI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountModel>
    {
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.AccountId);
            builder.Property(u => u.Username);
            builder.Property(u => u.Password);
            builder.Property(u => u.FirstName)
                .IsRequired(false);
            builder.Property(u => u.LastName)
                .IsRequired(false);
            builder.Property(u => u.Email);
            builder.Property(u => u.City)
                .IsRequired(false);
            builder.Property(u => u.Library);
            builder.Property(u => u.MaxBookQntToRent);
        }
    }
}
