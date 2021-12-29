using Hectre.Core.RequestModels;
using Hectre.Service.Interfaces;
using Hectre.Service.Services;
using Hectre.Storage.MongoDB;
using Hectre.Storage.MongoDB.DataAccess;
using Hectre.Storage.MongoDB.Interfaces;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Hectre.Service.Tests
{
    public class ChemicalsServiceTests
    {
        private readonly string _basePath = "api/v1/chemicals";

        private IChemicalsDataAccess _dataAccess;
        private IChemicalsService _service;

        public ChemicalsServiceTests()
        {
            
        }

        [SetUp]
        public void Setup()
        {
            var options = Options.Create(new ChemicalsDatabaseSettings
            {
                ConnectionString = "mongodb+srv://api_user:api_user_password@cluster0.p5bf3.mongodb.net/Hectre?retryWrites=true&w=majority",
                DatabaseName = "Hectre",
                ChemicalsCollectionName = "Chemicals",
            });

            _dataAccess = new ChemicalsDataAccess(options);
            _service = new ChemicalsService(_dataAccess);
        }

        [Test]
        public void GetAsync_Does_Not_Throw()
        {
            Assert.DoesNotThrow(() => new ChemicalsService(_dataAccess));
        }

        [Test]
        public async Task GetAsync_No_Pagination_Params()
        {
            var request = new ListChemicalsRequest();
            var response = await _service.GetAsync(_basePath, request);

            // Response should not be null
            Assert.NotNull(response);

            // Test that the amount of Chemicals returned are no more than the default value.
            Assert.LessOrEqual(response.Count, 10);
        }

        [Test]
        public async Task GetAsync_Links_Are_Returned()
        {
            var request = new ListChemicalsRequest();
            var response = await _service.GetAsync(_basePath, request);

            Assert.NotNull(response);
            Assert.NotNull(response.Links);
            Assert.GreaterOrEqual(response.Links.Count, 1);
        }

        [Test]
        public async Task CreateAsync()
        {
            var request = new CreateChemicalRequest
            {
                ChemicalType = "Surfactant",
                ActiveIngredient = "AMINOETHOXYVINYLGLYCINE",
                Name = "Dipel DF",
                PreHarvestInterval = "15",
            };

            var response = await _service.CreateAsync(request);

            Assert.NotNull(response);

            Assert.IsNotEmpty(response._id);

            Assert.AreEqual(response.chemicalType, request.ChemicalType);
            Assert.AreEqual(response.activeIngredient, request.ActiveIngredient);
            Assert.AreEqual(response.name, request.Name);
            Assert.AreEqual(response.preHarvestIntervalInDays, request.PreHarvestInterval);
        }
    }
}
