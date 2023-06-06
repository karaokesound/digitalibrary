namespace Library.UI.Service.Validation
{
    public interface INotUsedElementHidingService
    {
        public bool IsSignUpButtonClicked { get; }

        public void AdjustElementVisibility(bool isClicked);
    }
}
