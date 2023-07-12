using Library.Models.Model.many_to_many;
using System;
using System.Collections.Generic;

namespace Library.Models.Model
{
    public class GradeModel
    {
        public Guid GradeId { get; set; }

        public int Grade { get; set; }

        public ICollection<BookGradeModel> BookGrade { get; set; }

        public enum Grades : int
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
            F = 6,
            G = 7,
            H = 8,
            I = 9,
            J = 10
        };
    }
}
