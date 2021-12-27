using Hectre.Storage.MongoDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hectre.Storage.MongoDB.Interfaces
{
    public interface IChemicalsDataAccess
    {
        Task<ICollection<Chemical>> GetChemicals();

        Task<string> CreateChemical(Chemical chemical);
    }
}
