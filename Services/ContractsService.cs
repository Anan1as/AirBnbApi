using AirBnbApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirBnbApi.Services
{
    public class ContractsService
    {
        private readonly IMongoCollection<Contract> _contractsCollection;
        private readonly IMongoCollection<User> _usersCollection;
        private readonly IMongoCollection<House> _housesCollection;

        public ContractsService(IOptions<UserDatabaseSettings> userDatabaseSettings)
        {
            var mongoClient = new MongoClient(userDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);
            
            _contractsCollection = mongoDatabase.GetCollection<Contract>(userDatabaseSettings.Value.ContractsCollectionName);
            _usersCollection = mongoDatabase.GetCollection<User>(userDatabaseSettings.Value.UsersCollectionName);
            _housesCollection = mongoDatabase.GetCollection<House>(userDatabaseSettings.Value.HousesCollectionName);
        }

        public async Task<List<Contract>> GetAsync()
        {
            var contracts = await _contractsCollection.Find(_ => true).ToListAsync();
            foreach (var contract in contracts)
            {
                contract.User = await _usersCollection.Find(user => user.Id == contract.UserId).FirstOrDefaultAsync();
                contract.House = await _housesCollection.Find(house => house.Id == contract.HouseId).FirstOrDefaultAsync();
            }
            return contracts;
        }

        public async Task<Contract?> GetAsync(string id)
        {
            var contract = await _contractsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (contract != null)
            {
                contract.User = await _usersCollection.Find(user => user.Id == contract.UserId).FirstOrDefaultAsync();
                contract.House = await _housesCollection.Find(house => house.Id == contract.HouseId).FirstOrDefaultAsync();
            }
            return contract;
        }

        public async Task CreateAsync(Contract newContract) =>
            await _contractsCollection.InsertOneAsync(newContract);

        public async Task UpdateAsync(string id, Contract updatedContract) =>
            await _contractsCollection.ReplaceOneAsync(x => x.Id == id, updatedContract);

        public async Task RemoveAsync(string id) =>
            await _contractsCollection.DeleteOneAsync(x => x.Id == id);
    }
}