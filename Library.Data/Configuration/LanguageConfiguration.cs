using Library.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Library.Data.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<LanguageModel>
    {
        public void Configure(EntityTypeBuilder<LanguageModel> builder)
        {
            builder.ToTable("Languages");
            builder.HasKey(l => l.LanguageId);
            builder.Property(l => l.LanguageId).ValueGeneratedOnAdd();
            builder.Property(l => l.Language);
            builder.HasMany(b => b.Books)
                .WithMany(l => l.Languages);
        }
    }
}
