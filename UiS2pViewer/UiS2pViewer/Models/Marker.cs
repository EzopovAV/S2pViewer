using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Models
{
	public class Marker : IMarker
	{
		public string Name { get; set; }
		public double Frequence { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}
