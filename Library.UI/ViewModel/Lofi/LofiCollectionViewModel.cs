using Library.UI.Data;
using Library.UI.Model;
using Library.UI.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Library.UI.ViewModel
{
    public class LofiCollectionViewModel : BaseViewModel
    {
        public ObservableCollection<LofiViewModel> Lofies { get; set; }

        private readonly ILofiDataProvider _lofiDataProvider;

        public LofiCollectionViewModel(ILofiDataProvider lofiDataProvider)
        {
            _lofiDataProvider = lofiDataProvider;
            Lofies = new ObservableCollection<LofiViewModel>();
            GetAllLofi();
        }

        public void GetAllLofi()
        {
            if (Lofies.Any())
            {
                return;
            }

            List<Lofi> lofiList = _lofiDataProvider.GetAllLofi();
            foreach(Lofi lofi in lofiList)
            {
                LofiViewModel lofiVM = MappingService.LofiModelToViewModel(lofi);
                Lofies.Add(lofiVM);
            }
        }

    }
}
