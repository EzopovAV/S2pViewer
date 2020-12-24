using UiS2pViewer.Enums;

namespace UiS2pViewer.Models.Interfaces
{
	interface IFunction
	{
		string Name { get; set; }
		ISourceData SourceData { get; set; }
		Sparametrs Sparametrs { get; set; }
	}
}
