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
	public class GraphPanelViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Curve> Curves { get; set; }
		public GraphPanelViewModel(FrameworkElement context)
		{
			_context = context;
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
		FrameworkElement _context;

		private int _width;
		public int Width => (int)_context.ActualWidth;


		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

		public void AddCurve(double[] sourceDataX, double[] sourceDataY)
		{
			Curves.Add(new Curve(sourceDataX, sourceDataY,	Width,	new SolidColorBrush(Color.FromRgb(0, 200, 127)), Enums.LineType.solid));
		}
		public void AddCurve(double[] sourceDataX, double[] sourceDataY, Color color)
		{
			Curves.Add(new Curve(sourceDataX, sourceDataY, Width, new SolidColorBrush(color), Enums.LineType.solid));
		}
	}
}
