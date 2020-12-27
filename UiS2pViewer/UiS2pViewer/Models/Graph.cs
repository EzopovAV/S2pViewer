using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Models
{
	class Graph : IGraph
	{
		public string Name { get; set; }
		public XAxisSettings XAxisSettings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public YAxisSettings YAxisSettings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public YAxisSettings SecondYAxisSettings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool ShowGrid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Color GridColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool UseSecondYaxis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public List<IFunction> FunctionList { get; set; }
	}
}
