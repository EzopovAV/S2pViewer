using normalizerS2Pfiles;
using System.Collections.Generic;

namespace UiS2pViewer.Models.Interfaces
{
	public interface ISourceData
	{
		string Name { get; set; }
		string FullPathS2pFile { get; }
		IEnumerable<Sample> Samples { get; }
	}
}
