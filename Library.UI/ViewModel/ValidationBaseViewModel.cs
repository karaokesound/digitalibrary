using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Library.UI.ViewModel
{
    public class ValidationBaseViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errorsByPropertyName;

        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public ValidationBaseViewModel()
        {
            _errorsByPropertyName = new Dictionary<string, List<string>>();
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyName != null && _errorsByPropertyName.ContainsKey(propertyName)
                ? _errorsByPropertyName[propertyName]
                : Enumerable.Empty<string>();
        }

        public virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        protected void AddError(string error, [CallerMemberName]string? propertyName = null)
        {
            if (propertyName == null) return;

            if (!_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName] = new List<string>();
            }
            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        protected void ClearErrors([CallerMemberName]string? propertyName = null)
        {
            if (propertyName == null) return;

            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName].Clear();
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                OnPropertyChanged(nameof(HasErrors));
            }
        }
    }
}
