using Library.Models.Model.many_to_many;
using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System;
using System.Linq;

namespace Library.UI.Commands.Library
{
    public class BookDoubleClickCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IUserAuthenticationService _userAuthService;

        private readonly IBaseRepository<BookGradeModel> _bookgradeBaseRepository;

        public override void Execute(object parameter)
        {
            _libraryViewModel.AreBookDetailsVisible = true;
            _libraryViewModel.ShowBookGrade();
        }

        public BookDoubleClickCommand(LibraryViewModel libraryViewModel, IUserAuthenticationService userAuthService,
            IBaseRepository<BookGradeModel> bookgradeRepository)
        {
            _libraryViewModel = libraryViewModel;
            _userAuthService = userAuthService;
            _bookgradeBaseRepository = bookgradeRepository;
        }
    }
}
