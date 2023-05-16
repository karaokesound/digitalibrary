using Library.UI.Command;
using Library.UI.Model;
using Library.UI.Service;
using Library.UI.Services;
using Library.UI.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.Commands.Library
{
    public class DisplayBookCommand : CommandBase
    {
        private readonly IBaseRepository<BookModel> _baseRepository;

        private readonly LibraryViewModel _libraryVM;

        private readonly IMappingService _mappingService;

        public override void Execute(object parameter)
        {
            //List<BookModel> bookList = _baseRepository.GetAll().ToList();
            //foreach (var book in bookList)
            //{
            //    _libraryVM.BookList.Add(_mappingService.BookModelToViewModel(book));
            //}
            var books = _baseRepository.GetAll().ToList();
            foreach (var book in books)
            {
                _baseRepository.Delete(book.BookId);
                _baseRepository.Save();
            }
        }

        public DisplayBookCommand(LibraryViewModel libraryVM, IMappingService mappingService, IBaseRepository<BookModel> bookRepository)
        {
            _baseRepository = bookRepository;
            _mappingService = mappingService;
            _libraryVM = libraryVM;
        }
    }
}
