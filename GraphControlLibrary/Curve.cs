using GraphControlLibrary.Enums;
using System;
using System.Windows;
using System.Windows.Media;

namespace GraphControlLibrary
{
	public class Curve
	{
		private readonly double[] _sourceDataX;
		private readonly double[] _sourceDataY;
		private int _numberOfPointsToDisplay;
		private PointCollection _pointsToDisplay;

		public Curve(double[] sourceDataX, double[] sourceDataY, int numberOfPointsToDisplay, Brush brush, LineType type, int width = 1)
		{
			_sourceDataX = sourceDataX ?? throw new ArgumentNullException(nameof(sourceDataX));
			_sourceDataY = sourceDataY ?? throw new ArgumentNullException(nameof(sourceDataY));
			_numberOfPointsToDisplay = numberOfPointsToDisplay;
			Brush = brush;
			Type = type;
			Width = width;
		}

		public Brush Brush { get; set; }
		public LineType Type { get; set; }
		public int Width { get; set; }

		public int NumberOfPointsToDisplay
		{
			get => _numberOfPointsToDisplay;
			set
			{
				if (value != _numberOfPointsToDisplay)
				{
					_numberOfPointsToDisplay = value;
					_pointsToDisplay = CalculatePointsToDisplay(_sourceDataX, _sourceDataY, _numberOfPointsToDisplay);
				}
			}
		}

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
