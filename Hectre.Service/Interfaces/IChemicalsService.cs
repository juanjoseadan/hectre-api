using Hectre.Core.RequestModels;
using Hectre.Storage.MongoDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hectre.Service.Interfaces
{
    public interface IChemicalsService
    {
        Task<ICollection<Chemical>> GetAsync(ListChemicalsRequest request);

        Task<Chemical> CreateAsync(CreateChemicalRequest request);
    }
}
