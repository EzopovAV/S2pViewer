using System.Collections.Generic;
using System.Windows.Documents;
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
		List<IFunction> FunctionList { get; set; }
	}
}
