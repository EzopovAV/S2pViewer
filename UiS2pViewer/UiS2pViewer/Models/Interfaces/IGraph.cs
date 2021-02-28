using GraphControlLibrary;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace UiS2pViewer.Models.Interfaces
{
	public interface IGraph
	{
		string Name { get; set; }
		XAxisSettings XAxisSettings { get; set; }
		YAxisSettings YAxisSettings { get; set; }
		YAxisSettings SecondYAxisSettings { get; set; }
		bool ShowGrid { get; set; }
		Color GridColor { get; set; }
		bool UseSecondYaxis { get; set; }
		ObservableCollection<IFunction> FunctionList { get; set; }
		GraphPanelViewModel ViewModel { get; set; }
		ICommand AddNewFunctionCommand { get; }
	}
}
