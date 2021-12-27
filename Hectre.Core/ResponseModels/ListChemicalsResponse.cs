using Hectre.Storage.MongoDB.Models;
using System.Collections.Generic;

namespace Hectre.Core.ResponseModels
{
    public class ListChemicalsResponse
    {
        public ICollection<Chemical> Chemicals { get; set; }

        public int Count { get; set; }

        public long Total { get; set; }

        public ICollection<Link> Links { get; set; }
    }
}
