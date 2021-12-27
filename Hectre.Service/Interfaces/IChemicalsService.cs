using Hectre.Core.RequestModels;
using Hectre.Core.ResponseModels;
using Hectre.Storage.MongoDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hectre.Service.Interfaces
{
    public interface IChemicalsService
    {
        Task<ListChemicalsResponse> GetAsync(string path, ListChemicalsRequest request);

        Task<Chemical> CreateAsync(CreateChemicalRequest request);
    }
}
