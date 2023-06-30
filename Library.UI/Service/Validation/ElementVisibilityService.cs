using Library.UI.ViewModel.Library;

namespace Library.UI.Service.Validation
{
    public class ElementVisibilityService : IElementVisibilityService
    {
        public BookViewModel SelectedBook { get; private set; }

        public bool IsSignUpButtonClicked { get; private set; }

        public bool IsReturnsPanelClicked { get; private set; }

        public bool IsListViewVisible { get; private set; }

        public bool AreBookDetailsVisible { get; private set; }

        public void ListViewSelectedBook(BookViewModel selectedBook)
        {
            SelectedBook = selectedBook;
        }

        public void AdjustElementVisibility(bool isClicked)
        {
            if (isClicked == true)
            {
                IsSignUpButtonClicked = true;
                return;
            }
            IsSignUpButtonClicked = false;
        }

        public void AdjustReturnsPanelVisibility(bool isClicked)
        {
            if (isClicked == true)
            {
                IsReturnsPanelClicked = true;
                return;
            }
            IsReturnsPanelClicked = false;
        }

        public void AdjustListViewVisibility(bool isVisible)
        {
            if (isVisible == false)
            {
                IsListViewVisible = false;
                return;
            }
            IsListViewVisible = true;
        }
    }
}
