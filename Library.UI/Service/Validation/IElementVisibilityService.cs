﻿namespace Library.UI.Service.Validation
{
    public interface IElementVisibilityService
    {
        public bool IsSignUpButtonClicked { get; }

        public bool IsReturnsPanelClicked { get; }

        public bool IsListViewVisible { get; }

        public void AdjustElementVisibility(bool isClicked);

        public void AdjustReturnsPanelVisibility(bool isClicked);

        public void AdjustListViewVisibility(bool isEmpty);
    }
}