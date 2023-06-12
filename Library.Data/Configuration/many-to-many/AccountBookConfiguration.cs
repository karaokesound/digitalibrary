using Library.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class AccountBookConfiguration : IEntityTypeConfiguration<AccountBookModel>
    {
          public void Configure(EntityTypeBuilder<AccountBookModel> builder)
        {
            builder.ToTable("AccountBooks");
            builder.HasKey(ab => new { ab.AccountId, ab.BookId });
            builder.Property(ab => ab.Quantity);

            builder.HasOne(ab => ab.Account)
                .WithMany(b => b.AccountBooks)
                .HasForeignKey(ab => ab.AccountId);

            builder.HasOne(ab => ab.Book)
                .WithMany(a => a.AccountBooks)
                .HasForeignKey(ab => ab.BookId);
        }
    }
}
