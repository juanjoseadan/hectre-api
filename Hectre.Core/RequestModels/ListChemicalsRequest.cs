namespace Hectre.Core.RequestModels
{
	public class ListChemicalsRequest
	{
		public int Take { get; set; } = 10;

		public int Skip { get; set; } = 0;
	}
}
