using System;

namespace Library.UI.ViewModel
{
    public class LofiViewModel : BaseViewModel
    {
        private Guid _id;

        public Guid Id
        {
            get =>  _id;
            set 
            { 
                _id = value; 
            }
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }

        private string _vibe;

        public string Vibe
        {
            get => _vibe;
            set
            {
                _vibe = value;
            }
        }
    }
}
