using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DarkSeng.ViewModel.General
{
    public class ViewModelBase : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        #region Vars

        private Dictionary<string, List<ValidationResult>> _errorsCollection = new Dictionary<string, List<ValidationResult>>();

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void FirePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Implementation of INotifyDataErrorInfo

        public IEnumerable GetErrors(string propertyName)
        {
            return (propertyName != null) && _errorsCollection.ContainsKey(propertyName) ? _errorsCollection[propertyName] : null;
        }

        public bool HasErrors => _errorsCollection.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected virtual void FireErrorsChanged(string propName)
        {
            var handler = ErrorsChanged;
            handler?.Invoke(this, new DataErrorsChangedEventArgs(propName));
            FirePropertyChanged(nameof(HasErrors));
        }

        protected void AddError(string propName, string errorMsg)
        {
            if (!_errorsCollection.ContainsKey(propName))
                _errorsCollection.Add(propName, new List<ValidationResult>());

            if (_errorsCollection[propName].Find(x => x.ErrorMessage == errorMsg) != null)
                return;


            _errorsCollection[propName].Add(new ValidationResult(errorMsg));
            FireErrorsChanged(propName);
        }

        protected void RemoveError(string propName, string errorMsg)
        {
            try
            {
                if (!_errorsCollection.ContainsKey(propName))
                    return;

                ValidationResult result = _errorsCollection[propName].First(x => x.ErrorMessage == errorMsg);
                if (result != null)
                {
                    _errorsCollection[propName].Remove(result);
                    if (_errorsCollection[propName].Count == 0)
                        _errorsCollection.Remove(propName);

                    FireErrorsChanged(propName);
                }
            }
            catch
            {
                // ignored
            }
        }

        protected void RemoveError(string propName)
        {
            if (!_errorsCollection.ContainsKey(propName))
                return;

            _errorsCollection.Remove(propName);
            FireErrorsChanged(propName);
        }

        protected void ClearAllErrors()
        {
            foreach (string source in _errorsCollection.Keys.ToList())
            {
                RemoveError(source);
            }
        }

        #endregion

    }
}