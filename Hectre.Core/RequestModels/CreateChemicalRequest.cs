namespace Hectre.Core.RequestModels
{
	public class CreateChemicalRequest
	{
		public string ChemicalType { get; set; }

		public string ActiveIngredient { get; set; }

		public string Name { get; set; }

		public string PreHarvestInterval { get; set; }
	}
}
