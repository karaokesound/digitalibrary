using Library.UI.Model;
using System.Collections.Generic;

namespace Library.UI.Data
{
    public interface ILofiDataProvider
    {
        public List<Lofi> GetAllLofi();
    }
}
