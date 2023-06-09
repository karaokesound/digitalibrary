using Library.UI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

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
            builder.Property(u => u.MaxQntOfRentedBooks);
            builder.Property(u => u.RentedBooks)
                .HasConversion
                (v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(guidStr => Guid.Parse(guidStr))
                .ToList());
        }
    }
}
