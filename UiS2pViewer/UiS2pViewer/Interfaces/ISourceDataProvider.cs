using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer.Interfaces
{
	public interface ISourceDataProvider
	{
		ISourceData GetSourceData(string fullPathS2pFile);
	}
}
