using EksamensprojektMedDatabaseAdgang.Models;
using System.Collections.Generic;

namespace EksamensprojektMedDatabaseAdgang.DataAccessLayer
{
    // Easier maintenance and modification of data access layer:

    // If the class that implements the interface is swapped out for another class that also implements this interface,
    // it should not affect the rest of the application, as long as the new class follows the same method signatures defined in this interface.

    // Low coupling: Does not need to be concerned with the specifics of how the data is being stored and retrieved,
    // as it can use the methods defined in the interface to interact with the data.
    public interface DAL_ITempWorker
    {
        M_TempWorker GetWorker(int id);

        List<M_TempWorker> GetAllWorkers();

        void CreateTempWorker(M_TempWorker worker);

        void UpdateWorker(M_TempWorker worker);

        void DeleteWorker(int id);
    }
}