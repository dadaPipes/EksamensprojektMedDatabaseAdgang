using EksamensprojektMedDatabaseAdgang.Commands;
using EksamensprojektMedDatabaseAdgang.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EksamensprojektMedDatabaseAdgang.ViewModels
{
    /*
     * ObservableCollection<TempWorker> implements INotifyCollectionChanged, which means that the view is notified when an item is added,
     * removed, or when the whole collection is refreshed.
     * This allows the user interface (UI) to be automatically updated when the underlying data changes.
     * You can then bind this ObservableCollection<TempWorker> to a UI control that supports collection binding
     * such as ListView, GridView, FlipView etc.
     */

    public class VM_TempWorkerRepository : INotifyPropertyChanged
    {
        private TempWorkerCommands _vmTempWorkerCommands;
        private M_TempWorker _mTempWorker;
        private M_TempWorkerRepository _mRepository;
        private VM_TempWorker _newTempWorker;
        private VM_TempWorker _selectedTempWorker;
        private ObservableCollection<VM_TempWorker> _vmTempWorkers;

        public VM_TempWorkerRepository()
        {
            _mTempWorker = new M_TempWorker();
            _newTempWorker = new VM_TempWorker();
            _selectedTempWorker = new VM_TempWorker(_mTempWorker);
            _mRepository = new M_TempWorkerRepository();
            _vmTempWorkers = new ObservableCollection<VM_TempWorker>();
        }

        public VM_TempWorker NewTempWorker
        {
            get => _newTempWorker;
            set => _newTempWorker = value;
        }

        public VM_TempWorker SelectedTempWorker
        {
            get => _selectedTempWorker;

            set
            {
                // Not really sure what is going on here
                if (_selectedTempWorker != value)
                {
                    _selectedTempWorker = value;
                    OnPropertyChanged(nameof(SelectedTempWorker));
                    M_TempWorker modelWorker = ToModel(_selectedTempWorker);
                    _mRepository.UpdateTempWorker(modelWorker);
                }
            }
        }

        public ObservableCollection<VM_TempWorker> VMTempWorkers
        {
            get => _vmTempWorkers;
            set
            {
                _vmTempWorkers = value;
                OnPropertyChanged(nameof(VMTempWorkers));
            }
        }

        
        public void UpdateTempWorker(VM_TempWorker updatedWorker)
        {
            UpdateTempWorkerInCollection(updatedWorker);
            OnPropertyChanged(nameof(SelectedTempWorker));
            M_TempWorker modelWorker = ToModel(_selectedTempWorker);
            _mRepository.UpdateTempWorker(modelWorker);
        }

        public VM_TempWorker GetTempWorker(int id)
        {
            M_TempWorker modelWorker = _mRepository.GetTempWorker(id);
            return new VM_TempWorker(modelWorker);
        }

        // Get rid of the ConvertAll as it does not copy the properties of VM_TempWorkers to M_TempWorkers
        // Also Change this method to a SearchTempWorker method. 
        public List<VM_TempWorker> GetAllTempWorkers(int id)
        {
            List<M_TempWorker> modelWorkers = _mRepository.GetAllTempWorkers();
            return modelWorkers.ConvertAll(x => new VM_TempWorker(x));
        }

        public void CreateTempWorker()
        {
            var newWorker = new VM_TempWorker();
            VMTempWorkers.Add(newWorker);
            M_TempWorker modelWorker = ToModel(newWorker);
            _mRepository.CreateTempWorker(modelWorker);
        }

        public void DeleteTempWorker(int tempWorkerId)
        {
            VM_TempWorker tempWorker = _vmTempWorkers.FirstOrDefault(x => x.Id == tempWorkerId);
            if (tempWorker != null)
            {
                _vmTempWorkers.Remove(tempWorker);
                M_TempWorker modelWorker = ToModel(tempWorker);
                _mRepository.DeleteTempWorker(tempWorkerId);
            }
        }

        private M_TempWorker ToModel(VM_TempWorker worker)
        {
            return new M_TempWorker()
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Address = worker.Address,
                City = worker.City,
                ZipCode = worker.ZipCode,
                PersonalNumber = worker.PersonalNumber,
                IsActive = worker.IsActive,
            };
        }

        private void UpdateTempWorkerInCollection(VM_TempWorker updatedWorker)
        {
            var index = _vmTempWorkers.Select((item, i) => new { item, i }).First(x => x.item.Id == updatedWorker.Id).i;
            _vmTempWorkers.Insert(index, updatedWorker);
        }

        public ICommand GetTempWorkerCommand => _vmTempWorkerCommands.GetTempWorkerCommand;
        public ICommand GetAllTempWorkersCommand => _vmTempWorkerCommands.GetAllTempWorkersCommand;
        public ICommand CreateTempWorkerCommand => _vmTempWorkerCommands.CreateTempWorkerCommand;
        public ICommand UpdateTempWorkerCommand => _vmTempWorkerCommands.UpdateTempWorkerCommand;
        public ICommand DeleteTempWorkerCommand => _vmTempWorkerCommands.DeleteTempWorkerCommand;

        #region INottifyPropertyChanged_Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INottifyPropertyChanged_Implementation
    }
}