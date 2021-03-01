using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using UiS2pViewer.Enums;

namespace UiS2pViewer.Models.Interfaces
{
	public interface IFunction
	{
		string Name { get; set; }
		ISourceData SourceData { get; set; }
		IEnumerable<double> DataX { get; }
		IEnumerable<double> DataY { get; }
		Sparametrs Sparametrs { get; set; }
		Color Color { get; set; }
		ObservableCollection<IMarker> MarkerList { get; set; }
		ICommand AddNewMarkerCommand { get; }
	}
}
