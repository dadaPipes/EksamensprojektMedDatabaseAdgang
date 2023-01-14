using EksamensprojektMedDatabaseAdgang.DataAccessLayer;
using System.Collections.Generic;

namespace EksamensprojektMedDatabaseAdgang.Models
{
    // Decoupling:
    // Working with ITempWorkerDal (Interface), NOT the class TempWorkerRepository itself.
    // Can therefore be swiched with another Data Access Layer, without affecting the rest of the application.

    public class M_TempWorkerRepository
    {
        private DAL_ITempWorker _dal;

        public M_TempWorkerRepository()
        {
            // Default constructor
        }

        public M_TempWorkerRepository(DAL_ITempWorker dal)
        {
            _dal = dal;
        }

        public void UpdateTempWorker(M_TempWorker worker)
        {
            _dal.UpdateWorker(worker);
        }

        public M_TempWorker GetTempWorker(int id)
        {
            return _dal.GetWorker(id);
        }

        public List<M_TempWorker> GetAllTempWorkers()
        {
            return _dal.GetAllWorkers();
        }

        public void CreateTempWorker(M_TempWorker worker)
        {
            _dal.CreateTempWorker(worker);
        }

        public void DeleteTempWorker(int id)
        {
            _dal.DeleteWorker(id);
        }
    }
}