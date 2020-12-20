using normalizerS2Pfiles.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiS2pViewer.Models
{
	public class AxisSettings
	{
		public double Start { get; set; }
		public double Stop { get; set; }
		public double Center { get; set; }
		public double Span { get; set; }
		public FrequencyUnits FrequencyUnits { get; set; }
	}
}
