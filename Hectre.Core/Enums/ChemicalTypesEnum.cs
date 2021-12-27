using System.ComponentModel;

namespace Hectre.Core.Enums
{
	public enum ChemicalTypesEnum
	{
		[Description("Plant Growth Regulator")]
		PlantGrowthRegulator = 0,

		[Description("Surfactant")]
		Surfactant = 1,

		[Description("Tree Nutrition Fungicide")]
		TreeNutritionFungicide = 2,

		[Description("Pesticide")]
		Pesticide = 3,

		[Description("Bactericides And Fungicides")]
		BactericidesAndFungicides = 4,

		[Description("Insecticide")]
		Insecticide = 5,
	}
}
