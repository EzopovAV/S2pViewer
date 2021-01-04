using System.IO;
using UiS2pViewer.Interfaces;
using UiS2pViewer.Models;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer
{
	public class SourceDataProvider : ISourceDataProvider
	{
		public ISourceData GetSourceData(string fullPathS2pFile)
		{
			return new SourceData {
				FullPathS2pFile = fullPathS2pFile,
				Name = Path.GetFileName(fullPathS2pFile),
			};
		}
	}
}
