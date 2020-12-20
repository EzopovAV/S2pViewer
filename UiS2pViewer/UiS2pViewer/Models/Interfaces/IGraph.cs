using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UiS2pViewer.Models.Interfaces
{
	interface IGraph
	{
		string Name { get; set; }
		AxisSettings XaxisSettings { get; set; }
		AxisSettings YaxisSettings { get; set; }
		AxisSettings SecondYaxisSettings { get; set; }
		bool ShowGrid { get; set; }
		Color GridColor { get; set; }
		bool UseSecondYaxis { get; set; }
	}
}
