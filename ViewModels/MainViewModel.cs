using EksamensprojektMedDatabaseAdgang.Commands;
using EksamensprojektMedDatabaseAdgang.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EksamensprojektMedDatabaseAdgang.ViewModels
{
    // MainViewModel has a properties for VM_TempWorker and TempWorkerViewModel

    // Binding properties:
    // Text="{Binding TempWorkerViewModel.FirstName}"
    // ItemsSource="{Binding VM_TempWorkerRepository.VMTempWorkers}"

    public class MainViewModel : INotifyPropertyChanged
    {
        private TempWorkerCommands _tempWorkerCommands;
        private VM_TempWorker _vmTempWorker;
        private VM_TempWorkerRepository _vmTempWorkerRepository;

        public MainViewModel()
        {
            _vmTempWorker = new VM_TempWorker(new M_TempWorker());
            _vmTempWorkerRepository = new VM_TempWorkerRepository();
            _tempWorkerCommands= new TempWorkerCommands();
        }

        public MainViewModel(VM_TempWorker vmTempWorker, VM_TempWorkerRepository vmTempWorkerRepository, TempWorkerCommands tempWorkerCommands)
        {
            
            _vmTempWorker = vmTempWorker;
            _vmTempWorkerRepository = vmTempWorkerRepository;
            _tempWorkerCommands = tempWorkerCommands;
        }

        public TempWorkerCommands TempWorkerCommands;

        public VM_TempWorker VM_TempWorker
        {
            get { return _vmTempWorker; }
            set
            {
                _vmTempWorker = value;
                OnPropertyChanged();
            }
        }

        public VM_TempWorkerRepository VM_TempWorkerRepository
        {
            get { return _vmTempWorkerRepository; }
            set
            {
                _vmTempWorkerRepository = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}