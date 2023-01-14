using EksamensprojektMedDatabaseAdgang.Models;
using EksamensprojektMedDatabaseAdgang.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace EksamensprojektMedDatabaseAdgang.Commands
{
    public class TempWorkerCommands
    {
        private M_TempWorker _mTempWorker = new M_TempWorker();
        private VM_TempWorkerRepository vm_tempWorkerRepo;

        private RelayCommand _getTempWorkerCommand;
        private RelayCommand _getAllTempWorkersCommand;
        private RelayCommand _saveTempWorkerCommand;
        private RelayCommand _updateTempWorkerCommand;
        private RelayCommand _deleteTempWorkerCommand;

        public TempWorkerCommands()
        {
            // default constructor
        }

        public TempWorkerCommands(VM_TempWorkerRepository vm_tempWorkerRepo)
        {
            this.vm_tempWorkerRepo = vm_tempWorkerRepo;

            _getTempWorkerCommand = new RelayCommand(() => ExecuteGetTempWorker(this.vm_tempWorkerRepo), () => CanExecuteGetTempWorker(this.vm_tempWorkerRepo));
            _getAllTempWorkersCommand = new RelayCommand(() => ExecuteGetAllUsers(this.vm_tempWorkerRepo), () => CanExecuteGetAllTempWorkers(this.vm_tempWorkerRepo));
            _saveTempWorkerCommand = new RelayCommand(() => ExecuteCreateTempWorker(this.vm_tempWorkerRepo), () => CanExecuteCreateTempWorker(this.vm_tempWorkerRepo));
            _updateTempWorkerCommand = new RelayCommand(() => ExecuteUpdateTempWorker(this.vm_tempWorkerRepo), () => CanExecuteUpdateTempWorker(this.vm_tempWorkerRepo));
            _deleteTempWorkerCommand = new RelayCommand(() => ExecuteDeleteTempWorker(this.vm_tempWorkerRepo), () => CanExecuteDeleteTempWorker(this.vm_tempWorkerRepo));
        }

        public ICommand GetTempWorkerCommand => _getTempWorkerCommand;
        public ICommand GetAllTempWorkersCommand => _getAllTempWorkersCommand;
        public ICommand SaveTempWorkerCommand => _saveTempWorkerCommand;
        public ICommand UpdateTempWorkerCommand => _updateTempWorkerCommand;
        public ICommand DeleteTempWorkerCommand => _deleteTempWorkerCommand;

        private bool CanExecuteGetTempWorker(object parameter)
        {
            // Add logic to determine if the command can be executed
            return true;
        }

        private void ExecuteGetTempWorker(object parameter)
        {
            int id = (int)parameter;
            VM_TempWorker worker = vm_tempWorkerRepo.GetTempWorker(id);
        }

        private bool CanExecuteGetAllTempWorkers(object parameter)
        {
            // Add logic to determine if the command can be executed
            return true;
        }

        private void ExecuteGetAllUsers(object parameter)
        {
            List<VM_TempWorker> users = vm_tempWorkerRepo.GetAllTempWorkers(_mTempWorker.Id);
            // Update the UI with the returned list of users
        }

        private bool CanExecuteCreateTempWorker(object parameter)
        {
            // Add logic to determine if the command can be executed
            return true;
        }

        private void ExecuteCreateTempWorker(object parameter)
        {
            VM_TempWorker worker = (VM_TempWorker)parameter;
            vm_tempWorkerRepo.CreateTempWorker();
        }

        private bool CanExecuteUpdateTempWorker(object parameter)
        {
            // Add logic to determine if the command can be executed
            return true;
        }

        private void ExecuteUpdateTempWorker(object parameter)
        {
            VM_TempWorker worker = (VM_TempWorker)parameter;
            vm_tempWorkerRepo.UpdateTempWorker(worker);
        }

        private void ExecuteDeleteTempWorker(object parameter)
        {
            vm_tempWorkerRepo.DeleteTempWorker(_mTempWorker.Id);
        }

        private bool CanExecuteDeleteTempWorker(object parameter)
        {
            //  // Return true if the user can be deleted, false otherwise
            return true;
        }
    }
}