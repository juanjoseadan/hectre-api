using Hectre.Core.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Hectre.Storage.MongoDB.Models
{
	public class Chemical
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; }

		public string chemicalType { get; set; }

		[BsonSerializer(typeof(StringOrIntSerializer))]
		public string preHarvestIntervalInDays { get; set; }

        public string activeIngredient { get; set; }

        public string name { get; set; }

		public DateTime creationDate { get; set; }

		public DateTime? modificationDate { get; set; }

		public DateTime? deletionDate { get; set; }
	}
}
