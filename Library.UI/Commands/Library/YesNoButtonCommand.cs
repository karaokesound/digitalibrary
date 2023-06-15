using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class YesNoButtonCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Yes")
            {
                _libraryViewModel.IsRatingEnable = true;
                _libraryViewModel.IsRentExitButtonVisible = false;
                  
            }

            if (parameter.ToString() == "No")
            {
                _libraryViewModel.IsRentExitButtonVisible = true;
                _libraryViewModel.IsRatingEnable = false;
            }
        }

        public YesNoButtonCommand(LibraryViewModel libraryViewModel)
        {
            _libraryViewModel = libraryViewModel;
        }
    }
}
