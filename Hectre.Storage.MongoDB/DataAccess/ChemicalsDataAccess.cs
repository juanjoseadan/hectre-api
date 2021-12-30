using Hectre.Storage.MongoDB.Interfaces;
using Hectre.Storage.MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hectre.Storage.MongoDB.DataAccess
{
    public class ChemicalsDataAccess : IChemicalsDataAccess
    {
        private readonly MongoClient _client;
        private readonly string _collectionName;

        private readonly IMongoDatabase _database;

        public ChemicalsDataAccess(IOptions<ChemicalsDatabaseSettings> databaseSettings)
        {
            _collectionName = databaseSettings.Value.ChemicalsCollectionName;

            _client = new MongoClient(databaseSettings.Value.ConnectionString);
            _database = _client.GetDatabase(databaseSettings.Value.DatabaseName);
        }

        public async Task<Chemical> CreateAsync(Chemical chemical)
        {
            var collection = _database.GetCollection<Chemical>(_collectionName);

            await collection.InsertOneAsync(chemical);

            return chemical;
        }

        public async Task<ICollection<Chemical>> GetPaginatedAsync(int offset, int limit)
        {
            var collection = _database.GetCollection<Chemical>(_collectionName);
            var filter = Builders<Chemical>.Filter.Where(x => x.deletionDate == null);
            var sort = Builders<Chemical>.Sort.Ascending(x => x.chemicalType);

            return await collection
                .Find(filter)
                .Sort(sort)
                .Skip(offset)
                .Limit(limit)
                .ToListAsync();
        }

        public async Task<long> GetTotalAsync()
        {
            var collection = _database.GetCollection<Chemical>(_collectionName);
            var filter = Builders<Chemical>.Filter.Where(x => x.deletionDate == null);
            var sort = Builders<Chemical>.Sort.Ascending(x => x.chemicalType);

            return await collection
                .Find(filter)
                .Sort(sort)
                .CountDocumentsAsync();
        }
    }
}
