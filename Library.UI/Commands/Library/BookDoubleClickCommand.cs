using Library.Models.Model.many_to_many;
using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service.Validation;
using Library.UI.Services;
using Library.UI.ViewModel;
using Library.UI.ViewModel.Library;
using System;
using System.Linq;

namespace Library.UI.Commands.Library
{
    public class BookDoubleClickCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IElementVisibilityService _elementVisibilityService;

        private readonly IBaseRepository<BookGradeModel> _bookgradeBaseRepository;

        public override void Execute(object parameter)
        {
            BookViewModel selectedBook = _libraryViewModel.SelectedBook;

            bool areBookDetailsVisible = true;
            _elementVisibilityService.AdjustBookDetailsVisibility(areBookDetailsVisible);
            _libraryViewModel.AreBookDetailsVisible = _elementVisibilityService.AreBookDetailsVisible;

            Guid loggedUserID = _libraryViewModel.LoggedAccountId;
            
            // Check if user rated this book before
            var selectedBookUserGrade = _bookgradeBaseRepository.GetAll().Where(g => g.GradeAuthorId == loggedUserID && g.BookId == selectedBook.BookId);

            if (selectedBookUserGrade.Count() > 0)
            {
                _libraryViewModel.AreRatingStarsVisible = false;
                _libraryViewModel.IsBookGradeVisible = true;
                _libraryViewModel.ShowBookGrade();
                return;
            }

            _libraryViewModel.AreRatingStarsVisible = true;
            _libraryViewModel.IsBookGradeVisible = false;
            _libraryViewModel.ShowBookGrade();
        }

        public BookDoubleClickCommand(LibraryViewModel libraryViewModel, IElementVisibilityService elementVisibilityService, 
            IBaseRepository<BookGradeModel> bookgradeBaseRepository)
        {
            _libraryViewModel = libraryViewModel;
            _elementVisibilityService = elementVisibilityService;
            _bookgradeBaseRepository = bookgradeBaseRepository;
        }
    }
}
