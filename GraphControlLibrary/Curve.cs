using GraphControlLibrary.Enums;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace GraphControlLibrary
{
	public class Curve : INotifyPropertyChanged
	{
		private readonly double[] _sourceDataX;
		private readonly double[] _sourceDataY;

		public Curve(double[] sourceDataX, double[] sourceDataY, int numberOfPointsToDisplay, Brush brush, LineType type, int width = 1)
		{
			_sourceDataX = sourceDataX ?? throw new ArgumentNullException(nameof(sourceDataX));
			_sourceDataY = sourceDataY ?? throw new ArgumentNullException(nameof(sourceDataY));
			_numberOfPointsToDisplay = numberOfPointsToDisplay;
			Brush = brush;
			Type = type;
			Width = width;
		}

		private Brush _brush;
		public Brush Brush
		{
			get
			{
				return _brush;
			}
			set
			{
				_brush = value;
				OnPropertyChanged("Brush");
			}
		}

		private LineType _type;
		public LineType Type
		{
			get => _type;
			set
			{
				_type = value;
				OnPropertyChanged("Type");
			}
		}

		private int _width;
		public int Width
		{
			get => _width;
			set
			{
				_width = value;
				OnPropertyChanged("Width");
			}
		}

		private int _numberOfPointsToDisplay;
		public int NumberOfPointsToDisplay
		{
			get => _numberOfPointsToDisplay;
			set
			{
				if (value != _numberOfPointsToDisplay)
				{
					_numberOfPointsToDisplay = value;
					_pointsToDisplay = CalculatePointsToDisplay(_sourceDataX, _sourceDataY, _numberOfPointsToDisplay);
					OnPropertyChanged("NumberOfPointsToDisplay");
					OnPropertyChanged("PointsToDisplay");
				}
			}
		}

		private PointCollection _pointsToDisplay;
		public PointCollection PointsToDisplay
		{
			get
			{
				if(_pointsToDisplay == null)
				{
					_pointsToDisplay = CalculatePointsToDisplay(_sourceDataX, _sourceDataY, _numberOfPointsToDisplay);
				}

				return _pointsToDisplay;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

		private PointCollection CalculatePointsToDisplay(double[] sourceDataX, double[] sourceDataY, int numberOfPointsToDisplay)
		{
			PointCollection points = new PointCollection(numberOfPointsToDisplay);
			for (int i = 0; i < Math.Min(numberOfPointsToDisplay, Math.Min(sourceDataY.Length, sourceDataX.Length)); i++)
			{
				points.Add(new Point(sourceDataX[i], sourceDataY[i]));
			}
			return points; //todo return a uniform sample across the entire array
		}
	}
}
