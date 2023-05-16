using Library.UI.Command;
using Library.UI.Service;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class GetBookBaseCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryVM;


        private readonly IBookDatabase _bookDatabase;

        private readonly IMappingService _mappingService;

        public override void Execute(object parameter)
        {
            _bookDatabase.InsertsBooksToDatabase();
        }

        public GetBookBaseCommand(LibraryViewModel libraryVM, IBookDatabase bookDatabase, IMappingService mappingService)
        {
            _libraryVM = libraryVM;
            _bookDatabase = bookDatabase;
            _mappingService = mappingService;
        }
    }
}
