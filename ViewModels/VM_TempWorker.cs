using EksamensprojektMedDatabaseAdgang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EksamensprojektMedDatabaseAdgang.ViewModels
{
    public class VM_TempWorker : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private M_TempWorker _worker;

        public VM_TempWorker()
        {
            _worker = new M_TempWorker();
        }

        public VM_TempWorker(M_TempWorker worker)
        {
            _worker = worker;
        }

        public int Id
        {
            get { return _worker.Id; }
        }

        public string FirstName
        {
            get { return _worker.FirstName; }
            set
            {
                _errors.Remove(nameof(FirstName));
                if (string.IsNullOrWhiteSpace(value))
                {
                    _errors[nameof(FirstName)] = new List<string> { "First name is required." };
                }
                else if (value.Length > 50)
                {
                    _errors[nameof(FirstName)] = new List<string> { "First name must be 50 characters or less." };
                }
                _worker.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
                OnErrorsChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _worker.LastName; }
            set
            {
                _errors.Remove(nameof(LastName));
                if (string.IsNullOrWhiteSpace(value))
                {
                    _errors[nameof(LastName)] = new List<string> { "Last name is required." };
                }
                else if (value.Length > 50)
                {
                    _errors[nameof(LastName)] = new List<string> { "Last name must be 50 characters or less." };
                }
                _worker.LastName = value;
                OnPropertyChanged(nameof(LastName));
                OnErrorsChanged(nameof(LastName));
            }
        }

        public string Address
        {
            get { return _worker.Address; }
            set
            {
                _errors.Remove(nameof(Address));
                if (string.IsNullOrWhiteSpace(value))
                {
                    _errors[nameof(Address)] = new List<string> { "Address is required." };
                }
                else if (value.Length > 50)
                {
                    _errors[nameof(Address)] = new List<string> { "Address must be 50 characters or less." };
                }
                _worker.Address = value;
                OnPropertyChanged(nameof(Address));
                OnErrorsChanged(nameof(Address));
            }
        }

        public string City
        {
            get { return _worker.City; }
            set
            {
                _errors.Remove(nameof(City));
                if (string.IsNullOrWhiteSpace(value))
                {
                    _errors[nameof(City)] = new List<string> { "City name is required." };
                }
                else if (value.Length > 50)
                {
                    _errors[nameof(City)] = new List<string> { "City name must be 50 characters or less." };
                }
                _worker.City = value;
                OnPropertyChanged(nameof(City));
                OnErrorsChanged(nameof(City));
            }
        }

        public string ZipCode
        {
            get { return _worker.ZipCode; }
            set
            {
                _errors.Remove(nameof(ZipCode));
                try
                {
                    _errors.Remove(nameof(ZipCode));
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        _errors[nameof(ZipCode)] = new List<string> { "ZipCode must be 4 characters." };
                    }
                    else if (_worker.ZipCode.Length != 4)
                    {
                        _errors[nameof(ZipCode)] = new List<string> { "ZipCode must be 4 caracters" };
                    }
                    else
                    {
                        _worker.ZipCode = value;
                        OnPropertyChanged(nameof(ZipCode));
                        OnErrorsChanged(nameof(ZipCode));
                    }
                }
                // Go deeper in to this and exeption handling in generel
                catch (FormatException)
                {
                    _errors[nameof(ZipCode)] = new List<string> { "ZipCode must be a number." };
                }
            }
        }

        public string PersonalNumber
        {
            get { return _worker.PersonalNumber; }
            set
            {
                _errors.Remove(nameof(PersonalNumber));
                if (string.IsNullOrWhiteSpace(value))
                {
                    _errors[nameof(PersonalNumber)] = new List<string> { "Last name is required." };
                }
                else if (value.Length > 50)
                {
                    _errors[nameof(PersonalNumber)] = new List<string> { "First name must be 50 characters or less." };
                }
                _worker.PersonalNumber = value;
                OnPropertyChanged(nameof(PersonalNumber));
                OnErrorsChanged(nameof(PersonalNumber));
            }
        }

        public bool IsActive

        {
            get { return _worker.IsActive; }
            set
            {
                _worker.IsActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        public M_TempWorker ToModel(VM_TempWorker vmWorker)
        {
            return new M_TempWorker(vmWorker.Id, vmWorker.FirstName, vmWorker.LastName, vmWorker.Address, vmWorker.City, vmWorker.ZipCode, vmWorker.PersonalNumber, vmWorker.IsActive);
        }

        #region INottifyPropertyChanged_Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INottifyPropertyChanged_Implementation

        #region ExceptionHandling

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }

        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        private void OnErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        #endregion ExceptionHandling
    }
}