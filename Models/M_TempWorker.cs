namespace EksamensprojektMedDatabaseAdgang.Models
{
    public class M_TempWorker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string PersonalNumber { get; set; }
        public bool IsActive { get; set; }

        public M_TempWorker()
        {
            // Default constructor
        }

        public M_TempWorker(
            int id,
            string firstName,
            string lastName,
            string address,
            string city,
            string zipCode,
            string personalNumber,
            bool isActive)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            ZipCode = zipCode;
            PersonalNumber = personalNumber;
            IsActive = isActive;
        }
    }
}