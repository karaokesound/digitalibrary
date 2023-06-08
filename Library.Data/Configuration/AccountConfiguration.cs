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
            builder.HasKey(user => user.AccountId);
            builder.Property(user => user.Username);
            builder.Property(user => user.Password);
            builder.Property(user => user.FirstName)
                .IsRequired(false);
            builder.Property(user => user.LastName)
                .IsRequired(false);
            builder.Property(user => user.Email);
            builder.Property(user => user.City)
                .IsRequired(false);
            builder.Property(user => user.Library);
        }
    }
}
