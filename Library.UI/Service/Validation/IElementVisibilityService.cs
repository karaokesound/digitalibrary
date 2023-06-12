namespace Library.UI.Service.Validation
{
    public interface IElementVisibilityService
    {
        public bool IsSignUpButtonClicked { get; }

        public void AdjustElementVisibility(bool isClicked);
    }
}
