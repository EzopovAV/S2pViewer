using normalizerS2Pfiles.Enums;
using normalizerS2Pfiles.Interfaces;
using System;
using System.Linq;

namespace normalizerS2Pfiles
{
	public class S2PReader : IS2PReader
	{
		public S2PFormat GetFormat(string[] source)
		{
			var s2PFormat = new S2PFormat();

			var formatString = GetFormatString(source);

			s2PFormat.FrequencyUnits = GetFreqUnit(formatString);
			s2PFormat.DataUnits = GetDataUnit(formatString);

			return s2PFormat;
		}
		private string GetFormatString(string[] source)
		{
			int i = 0;
			while (source[i].FirstOrDefault() != '#')
			{
				i++;
				if (i == source.Length)
				{
					throw new Exception("No data format string was found.");
				}
			}
			var formatString = source[i];
			return formatString;
		}

		private FrequencyUnits GetFreqUnit(string formatString)
		{
			var frequencyUnit = formatString.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[1];

			foreach (FrequencyUnits unit in Enum.GetValues(typeof(FrequencyUnits)))
			{
				if (string.Equals(unit.ToString(), frequencyUnit, StringComparison.InvariantCultureIgnoreCase))
				{
					return unit;
				}
			}

			throw new Exception("Invalid frequency units.");
		}

		private DataUnits GetDataUnit(string formatString)
		{
			var dataUnit = formatString.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[3];

			foreach (DataUnits unit in Enum.GetValues(typeof(DataUnits)))
			{
				if (string.Equals(unit.ToString(), dataUnit, StringComparison.InvariantCultureIgnoreCase))
				{
					return unit;
				}
			}

			throw new Exception("Invalid data units.");
		}
	}
}
