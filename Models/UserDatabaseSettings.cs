namespace AirBnbApi.Models
{
    public class UserDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UsersCollectionName { get; set; } = null!;

        public string HousesCollectionName { get; set; } = null!;

        public string ContractsCollectionName { get; set; } = null!;
    }
}