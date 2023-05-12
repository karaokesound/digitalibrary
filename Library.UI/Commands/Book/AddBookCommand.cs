using Library.UI.Model;
using Library.UI.ViewModel;
using System;

namespace Library.UI.Command
{
    public class AddBookCommand : CommandBase
    {
        private readonly BookCollectionViewModel _bookCollectionVM;

        public override void Execute(object parameter)
        { 
            //BookModel newBook = new BookModel()
            //{
            //    Id = Guid.NewGuid(),
            //    Title = _bookCollectionVM.NewBookVM.Title,
            //    Pages = _bookCollectionVM.NewBookVM.Pages
            //};
            //_bookCollectionVM.AddBook(newBook);
            //_bookCollectionVM.GetAllBooks();
        }

        public AddBookCommand(BookCollectionViewModel bookCollectionVM)
        {
            _bookCollectionVM = bookCollectionVM;
        }
    }
}
