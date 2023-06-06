namespace Library.UI.Service.Validation
{
    public class NotUsedElementHidingService : INotUsedElementHidingService
    {
        public bool IsSignUpButtonClicked { get; private set; }

        public void AdjustElementVisibility(bool isClicked)
        {
            if (isClicked == true)
            {
                IsSignUpButtonClicked = true;
                return;
            }
            IsSignUpButtonClicked = false;
        }
    }
}
