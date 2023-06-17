using Library.UI.Command;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class YesNoButtonCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryViewModel;

        public override void Execute(object parameter)
        {
            //if (parameter.ToString() == "No")
            //{
            //    _libraryViewModel.AreYesNoButtonsVisible = false;
            //    _libraryViewModel.AreRatingStarsVisible = false;
            //    _libraryViewModel.IsBookGradeVisible = true;
            //    _libraryViewModel.ShowBookGrade();
            //    return;
            //}

            //if (parameter.ToString() == "Yes")
            //{
            //    _libraryViewModel.AreRatingStarsVisible = true;
            //    _libraryViewModel.AreYesNoButtonsVisible = false;
            //    return;
            //}
        }

        public YesNoButtonCommand(LibraryViewModel libraryViewModel)
        {
            _libraryViewModel = libraryViewModel;
        }
    }
}
