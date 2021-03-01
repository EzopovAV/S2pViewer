using System.Collections.Generic;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Interfaces
{
	public interface IGraphFactory
	{
		IGraph GetGraph(IEnumerable<ISourceData> sourceDatas);
	}
}
