using EksamensprojektMedDatabaseAdgang.DataAccessLayer;
using EksamensprojektMedDatabaseAdgang.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

//Consider using a SqlDataAdapter and a DataSet or DataTable to load the data from the database, rather than using a SqlDataReader.
//This would allow you to keep the connection open for a shorter period of time, which can be more efficient.

//It might be a good idea to add some error handling and logging to the code in case something goes wrong while interacting with the database.

//consider using an ORM (Object-Relational Mapping) framework like Entity Framework to simplify the data access code
//and reduce the amount of boilerplate code you have to write.

namespace EksamensprojektMedDatabaseAdgang.PersistenceLayer
{
    public class DAL_TempWorkerRepository : DAL_ITempWorker, IDisposable
    {
        private DbConnection _connection;

        public DAL_TempWorkerRepository()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            string connectionString = dbConnection.GetConnectionString();
            _connection = new SqlConnection(connectionString);
        }



        public M_TempWorker GetWorker(int id)
        {
            try
            {
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM TempWorkers WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new M_TempWorker
                            {
                                Id = (int)reader["Id"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Address = (string)reader["Address"],
                                City = (string)reader["City"],
                                ZipCode = (string)reader["ZipCode"],
                                PersonalNumber = (string)reader["PersonalNumber"],
                                IsActive = (bool)reader["IsActive"],
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public List<M_TempWorker> GetAllWorkers()
        {
            try
            {
                List<M_TempWorker> workers = new List<M_TempWorker>();

                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM TempWorkers";

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            workers.Add(new M_TempWorker
                            {
                                Id = (int)reader["Id"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Address = (string)reader["Address"],
                                City = (string)reader["City"],
                                ZipCode = (string)reader["ZipCode"],
                                PersonalNumber = (string)reader["PersonalNumber"],
                                IsActive = (bool)reader["IsActive"],
                            });
                        }
                    }
                }
                return workers;
            }
            catch (Exception ex)
            {
                HandleException(ex);

                // returns an empty list so the program can continue execution and not crash due to the exception.
                return new List<M_TempWorker>();
            }
        }

        public void CreateTempWorker(M_TempWorker worker)
        {
            try
            {
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO TempWorkers (FirstName, LastName, Address, City, ZipCode, PersonalNumber,IsActive) " +
                        "VALUES (@FirstName, @LastName, @Address, @City, @ZipCode, @PersonalNumber, @IsActive)";
                    command.Parameters.Add(new SqlParameter("@FirstName", worker.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.LastName));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.Address));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.City));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.ZipCode));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.PersonalNumber));
                    command.Parameters.Add(new SqlParameter("@IsActive", worker.IsActive));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void UpdateWorker(M_TempWorker worker)
        {
            try
            {
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "UPDATE TempWorkers SET FirstName = @FirstName, LastName = @LastName, @Address, @City, @ZipCode, @PersonalNumber, IsActive = @IsActive WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@FirstName", worker.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.LastName));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.Address));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.City));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.ZipCode));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.PersonalNumber));
                    command.Parameters.Add(new SqlParameter("@IsActive", worker.IsActive));
                    command.Parameters.Add(new SqlParameter("@Id", worker.Id));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void DeleteWorker(int id)
        {
            try
            {
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM TempWorkers WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            // Log the exception
            // Send an email or notification to the administrator
            // Show a message to the user
            // etc.
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}