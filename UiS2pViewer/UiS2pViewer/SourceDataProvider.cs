using normalizerS2Pfiles;
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
			return new SourceData(
				fullPathS2pFile,
				new S2pFileService(fullPathS2pFile).GetSamples(), 
				Path.GetFileName(fullPathS2pFile));
		}
	}
}
