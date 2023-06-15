namespace Library.UI.Service.Validation
{
    public class ElementVisibilityService : IElementVisibilityService
    {
        public bool IsSignUpButtonClicked { get; private set; }

        public bool IsReturnsPanelClicked { get; private set; }

        public bool IsListViewVisible { get; private set; }

        public bool AreBookDetailsVisible { get; private set; }

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

        public void AdjustBookDetailsVisibility(bool isClicked)
        {
            if (isClicked == true)
            {
                AreBookDetailsVisible = true;
                return;
            }
            AreBookDetailsVisible = false;
        }
    }
}
