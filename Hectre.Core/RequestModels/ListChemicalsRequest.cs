namespace Hectre.Core.RequestModels
{
	public class ListChemicalsRequest
	{
		public int Limit { get; set; } = 10;

		public int Offset { get; set; } = 0;
	}
}
