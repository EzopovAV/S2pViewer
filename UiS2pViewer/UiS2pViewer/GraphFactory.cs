using System.Collections.Generic;
using System.Collections.ObjectModel;
using UiS2pViewer.Interfaces;
using UiS2pViewer.Models;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer
{
	public class GraphFactory : IGraphFactory
	{
		public IGraph GetGraph(IEnumerable<ISourceData> sourceDatas)
		{
			return new Graph(sourceDatas) { Name = "New graph", FunctionList = new ObservableCollection<IFunction>(), ViewModel = new GraphControlLibrary.GraphPanelViewModel() };
		}
	}
}
