using Library.Models.Model.many_to_many;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration.many_to_many
{
    public class BookGradeConfiguration : IEntityTypeConfiguration<BookGradeModel>
    {
        public void Configure(EntityTypeBuilder<BookGradeModel> builder)
        {
            builder.ToTable("BookGrades");
            builder.HasKey(bg => new { bg.BookId, bg.GradeId });
            builder.Property(bg => bg.GradeAuthorId);

            builder.HasOne(bg => bg.Book)
                .WithMany(r => r.BookGrade)
                .HasForeignKey(bg => bg.BookId);

            builder.HasOne(bg => bg.Grade)
                .WithMany(b => b.BookGrade)
                .HasForeignKey(bg => bg.GradeId);
        }
    }
}
