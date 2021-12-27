using Hectre.Core.RequestModels;
using Hectre.Storage.MongoDB.Models;
using System;

namespace Hectre.Service.Extensions
{
    public static class ModelExtensions
    {
        public static Chemical ToStorageModel(this CreateChemicalRequest request)
        {
            return new Chemical
            {
                chemicalType = request.ChemicalType,
                preHarvestIntervalInDays = request.PreHarvestInterval,
                activeIngredient = request.ActiveIngredient,
                name = request.Name,
                creationDate = DateTime.UtcNow,
            };
        }
    }
}
