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

        public async Task<string> CreateChemical(Chemical chemical)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Chemical>> GetChemicals()
        {
            var result = _database.GetCollection<Chemical>(_collectionName);
            return await result.Find(_ => true).ToListAsync();
        }
    }
}
