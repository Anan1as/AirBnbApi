using AirBnbApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AirBnbApi.Services
{
    public class HousesService
    {
        private readonly IMongoCollection<House> _housesCollection;

        public HousesService(IOptions<UserDatabaseSettings> userDatabaseSettings)
        {
            var mongoClient = new MongoClient(userDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);
            _housesCollection = mongoDatabase.GetCollection<House>(userDatabaseSettings.Value.HousesCollectionName);
        }

        public async Task<List<House>> GetAsync() =>
            await _housesCollection.Find(_ => true).ToListAsync();

        public async Task<House?> GetAsync(string id) =>
            await _housesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(House newHouse) =>
            await _housesCollection.InsertOneAsync(newHouse);

        public async Task UpdateAsync(string id, House updatedHouse) =>
            await _housesCollection.ReplaceOneAsync(x => x.Id == id, updatedHouse);

        public async Task RemoveAsync(string id) =>
            await _housesCollection.DeleteOneAsync(x => x.Id == id);
    }
}