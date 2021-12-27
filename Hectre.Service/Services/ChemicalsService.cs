using Hectre.Core.RequestModels;
using Hectre.Core.ResponseModels;
using Hectre.Service.Extensions;
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

        public async Task<ListChemicalsResponse> GetAsync(string path, ListChemicalsRequest request)
        {
            var response = new ListChemicalsResponse();

            response.Chemicals = await _chemicals.GetPaginatedAsync(request.Offset, request.Limit);
            response.Total = await _chemicals.GetTotalAsync();
            response.Count = response.Chemicals.Count;
            response.Links = ResponsePaginationHelper.GetPaginationLinks(
                path, request.Offset, request.Limit, response.Total, response.Count);

            return response;
        }

        public async Task<Chemical> CreateAsync(CreateChemicalRequest request) => await _chemicals.CreateAsync(request.ToStorageModel());
    }

    static class ResponsePaginationHelper
    {
        public static ICollection<Link> GetPaginationLinks(string path, int offset, int limit, long total, int count)
        {
            var links = new List<Link>();

            links.Add(new Link
            {
                Id = "current",
                Name = "Url to get the current selection of chemicals",
                Href = $"{path}?offset={offset}&limit={limit}",
            });

            // Validate that the current selection is not the last page
            if ((count + offset) < total)
            {
                links.Add(new Link
                {
                    Id = "next",
                    Name = "Url to get the next set of chemicals",
                    Href = $"{path}?offset={offset + limit}&limit={limit}"
                });
            }

            // Validate that the current selection is not the first page
            if (offset > 0)
            {
                var prevOffset = offset - limit;

                links.Add(new Link
                {
                    Id = "previous",
                    Name = "Url to get the previous set of chemicals",
                    Href = $"{path}?offset={(prevOffset < 0 ? 0 : prevOffset)}&limit={limit}"
                });
            }

            return links;
        }
    }
}
