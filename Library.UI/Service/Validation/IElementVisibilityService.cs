﻿using Library.UI.ViewModel.Library;

namespace Library.UI.Service.Validation
{
    public interface IElementVisibilityService
    {
        BookViewModel SelectedBook { get; }

        bool IsSignUpButtonClicked { get; }

        bool IsReturnsPanelClicked { get; }

        bool IsListViewVisible { get; }

        bool AreBookDetailsVisible { get; }

        void ListViewSelectedBook(BookViewModel selectedBook);

        void AdjustElementVisibility(bool isClicked);

        void AdjustReturnsPanelVisibility(bool isClicked);

        void AdjustListViewVisibility(bool isEmpty);
    }
}
