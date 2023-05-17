using Library.UI.Command;
using Library.UI.Service;
using Library.UI.ViewModel;

namespace Library.UI.Commands.Library
{
    public class GetBookBaseCommand : CommandBase
    {
        private readonly LibraryViewModel _libraryVM;

        private readonly IMappingService _mappingService;

        public override void Execute(object parameter)
        {
        }

        public GetBookBaseCommand(LibraryViewModel libraryVM, IMappingService mappingService)
        {
            _libraryVM = libraryVM;
            _mappingService = mappingService;
        }
    }
}
