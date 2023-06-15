using Library.UI.Command;
using Library.UI.Service.Validation;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class BookDoubleClickCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        private readonly IElementVisibilityService _elementVisibilityService;

        public override void Execute(object parameter)
        {
            bool areBookDetailsVisible = true;
            _elementVisibilityService.AdjustBookDetailsVisibility(areBookDetailsVisible);
            _libraryViewModel.AreBookDetailsVisible = _elementVisibilityService.AreBookDetailsVisible;
        }

        public BookDoubleClickCommand(LibraryViewModel libraryViewModel, IElementVisibilityService elementVisibilityService)
        {
            _libraryViewModel = libraryViewModel;
            _elementVisibilityService = elementVisibilityService;
        }
    }
}
