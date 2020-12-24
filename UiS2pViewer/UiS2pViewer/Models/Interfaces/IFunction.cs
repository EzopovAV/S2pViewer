using System.Collections.Generic;
using System.Windows.Media;
using UiS2pViewer.Enums;

namespace UiS2pViewer.Models.Interfaces
{
	public interface IFunction
	{
		string Name { get; set; }
		ISourceData SourceData { get; set; }
		Sparametrs Sparametrs { get; set; }
		Color Color { get; set; }
		List<IMarker> MarkerList { get; set; }
	}
}
