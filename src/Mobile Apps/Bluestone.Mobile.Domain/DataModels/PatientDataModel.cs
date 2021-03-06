using Bluestone.Mobile.Domain.DataModels;
using SQLite;


namespace Bluestone.Mobile.Domain.IDataStore
{
    public class PatientDataModel : IDatabaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public bool IsFavorite { get; set; }
    }
}
