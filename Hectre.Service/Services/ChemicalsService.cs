using Hectre.Core.RequestModels;
using Hectre.Service.Interfaces;
using Hectre.Storage.MongoDB.Interfaces;
using Hectre.Storage.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hectre.Service.Services
{
    public class ChemicalsService : IChemicalsService
    {
        private readonly IChemicalsDataAccess _chemicals;

        public ChemicalsService(IChemicalsDataAccess chemicals)
        {
            _chemicals = chemicals;
        }

        public async Task<ICollection<Chemical>> GetAsync(ListChemicalsRequest request)
        {
            return await _chemicals.GetChemicals();
        }

        public async Task<Chemical> CreateAsync(CreateChemicalRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
