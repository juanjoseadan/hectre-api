using Hectre.Core.Enums;

namespace Hectre.Core.RequestModels
{
	public class CreateChemicalRequest
	{
		public ChemicalTypesEnum ChemicalType { get; set; }

		public string ActiveIngredient { get; set; }

		public string Name { get; set; }

		public string PreHarvestInterval { get; set; }
	}
}
