using Library.UI.Model;
using Library.UI.ViewModel;

namespace Library.UI.Services
{
    public static class MappingService
    {
        // BOOKS MAPPING SERVICE //
        public static BookViewModel BookModelToViewModel (Book bookModel)
        {
            BookViewModel bookViewModel = new BookViewModel()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Volume = bookModel.Volume,
                Pages = bookModel.Pages,
            };
            return bookViewModel;
        }

        public static Book BookViewModelToModel (BookViewModel bookViewModel)
        {
            Book bookModel = new Book()
            {
                Id = bookViewModel.Id,
                Title = bookViewModel.Title,
                Volume = bookViewModel.Volume,
                Pages = bookViewModel.Pages,
            };
            return bookModel;
        }

        // LOFI MAPPING SERVICE //
        public static LofiViewModel LofiModelToViewModel (Lofi lofi)
        {
            return new LofiViewModel
            {
                Id = lofi.Id,
                Title = lofi.Title,
                Vibe = lofi.Vibe,
            };
        }

        public static Lofi LofiViewModelToModel(LofiViewModel lofiVM)
        {
            return new Lofi
            {
                Id = lofiVM.Id,
                Title = lofiVM.Title,
                Vibe = lofiVM.Vibe,
            };
        }
    }
}
