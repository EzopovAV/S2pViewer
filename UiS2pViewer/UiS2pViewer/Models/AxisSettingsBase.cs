using normalizerS2Pfiles.Enums;

namespace UiS2pViewer.Models
{
	public abstract class AxisSettingsBase
	{
		public double Start { get; set; }
		public double Stop { get; set; }
		public double Center { get; set; }
		public double Span { get; set; }
	}
}
