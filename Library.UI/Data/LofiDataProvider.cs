using Library.UI.Model;
using System;
using System.Collections.Generic;

namespace Library.UI.Data
{
    public class LofiDataProvider : ILofiDataProvider
    {
        public List<Lofi> GetAllLofi()
        {
            return new List<Lofi>
            {
                new Lofi { Id = Guid.NewGuid(), Title = "Lofi nr 1", Vibe = "Coding"},
                new Lofi { Id = Guid.NewGuid(), Title = "Lofi nr 2", Vibe = "Gaming"},
                new Lofi { Id = Guid.NewGuid(), Title = "Lofi nr 3", Vibe = "Coding"},
            };
        }
    }
}
