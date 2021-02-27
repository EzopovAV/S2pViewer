using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphControlLibrary
{
	public class GraphPanelViewModel
	{
		public ObservableCollection<Curve> Curves { get; set; }
		public GraphPanelViewModel()
		{
			Curves = new ObservableCollection<Curve>();
		}

		public void AddCurve(double[] sourceDataX, double[] sourceDataY)
		{
			Curves.Add(new Curve(sourceDataX, sourceDataY, sourceDataX.Length,	new SolidColorBrush(Color.FromRgb(0, 200, 127)), Enums.LineType.solid));
		}
		public void AddCurve(double[] sourceDataX, double[] sourceDataY, Color color)
		{
			Curves.Add(new Curve(sourceDataX, sourceDataY, sourceDataX.Length, new SolidColorBrush(color), Enums.LineType.solid));
		}
	}
}
