using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphControlLibrary
{
	public class GraphPanelViewModel
	{
		public ObservableCollection<Curve> Curves { get; set; }

		public GraphPanelViewModel()
		{
			Curves = new ObservableCollection<Curve>
			{
				new Curve(
					new double[]{10, 30, 50, 70, 90, 110, 130, 150, 170, 190},
					new double[]{150, 140, 170, 120, 190, 100, 210, 80, 230, 60},
					10,
					new SolidColorBrush(Color.FromRgb(0, 200, 127)),
					Enums.LineType.solid),

				new Curve(
					new double[]{150, 140, 170, 120, 190, 100, 210, 80, 230, 60},
					new double[]{10, 30, 50, 70, 90, 110, 130, 150, 170, 190},
					10,
					new SolidColorBrush(Color.FromRgb(0, 127, 200)),
					Enums.LineType.solid),
			};
		}
	}
}
