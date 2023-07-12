using Library.Models.Model;
using Library.Models.Model.many_to_many;
using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.Commands.Library
{
    public class AddGradeCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IBaseRepository<BookGradeModel> _bookgradeBaseRepository;

        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IUserAuthenticationService _userAuthenticationService;

        private readonly IBaseRepository<GradeModel> _gradeBaseRepository;

        public override void Execute(object parameter)
        {
            if (_libraryViewModel.SelectedBook == null) return;

            Guid loggedUserID = _userAuthenticationService.LoggedUser.AccountId;
            BookModel selectedBook = _bookBaseRepository.GetByID(_libraryViewModel.SelectedBook.BookId);

            int userGrade = int.Parse(parameter.ToString());

            List<GradeModel> dbGradeList = _gradeBaseRepository.GetAll().ToList();
            var matchedGrade = dbGradeList.FirstOrDefault(g => g.Grade == userGrade);

            List<BookGradeModel> bookGrades = new List<BookGradeModel>();
            BookGradeModel newBookgrade = new BookGradeModel()
            {
                BookGradeId = Guid.NewGuid(),
                BookId = selectedBook.BookId,
                GradeId = matchedGrade.GradeId,
                GradeAuthorId = loggedUserID
            };

            bookGrades.Add(newBookgrade);
            selectedBook.BookGrade = bookGrades;

            _bookgradeBaseRepository.Insert(newBookgrade);
            _bookgradeBaseRepository.Save();
            _bookBaseRepository.Save();

            _libraryViewModel.AreRatingStarsVisible = false;
            _libraryViewModel.IsBookGradeVisible = true;
            _libraryViewModel.ShowBookGrade();
        }

        public AddGradeCommand(LibraryViewModel libraryViewModel, IBaseRepository<BookGradeModel> bookgradeBaseRepository,
            IBaseRepository<BookModel> bookBaseRepository, IUserAuthenticationService userAuthenticationService, IBaseRepository<GradeModel> gradeBaseRepository)
        {
            _libraryViewModel = libraryViewModel;
            _bookgradeBaseRepository = bookgradeBaseRepository;
            _bookBaseRepository = bookBaseRepository;
            _userAuthenticationService = userAuthenticationService;
            _gradeBaseRepository = gradeBaseRepository;
        }
    }
}
