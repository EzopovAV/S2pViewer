using System.Windows.Media;

namespace UiS2pViewer.Models.Interfaces
{
	public interface IMarker
	{
		string Name { get; set; }
		double Frequence { get; set; }
		Color Color { get; set; }
	}
}
