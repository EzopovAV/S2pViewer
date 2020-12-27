using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UiS2pViewer.Enums;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Models
{
	class Function : IFunction
	{
		public string Name { get; set; }
		public ISourceData SourceData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Sparametrs Sparametrs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public List<IMarker> MarkerList { get; set; }
	}
}
