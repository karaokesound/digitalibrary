using Library.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class GradeConfiguration : IEntityTypeConfiguration<GradeModel>
    {
        public void Configure(EntityTypeBuilder<GradeModel> builder)
        {
            builder.ToTable("Grades");
            builder.HasKey(g => g.GradeId);
            builder.Property(g => g.GradeId).ValueGeneratedOnAdd();
            builder.Property(g => g.Grade);
        }
    }
}
