using System;
using normalizerS2Pfiles.Enums;

namespace normalizerS2Pfiles.S2pProvider
{
	public class MaS2PProvider : BaseS2PProvider
	{
		public MaS2PProvider(FrequencyUnits frequencyUnits)
			: base(frequencyUnits)
		{
		}

		protected override Sample[] ConvertDataTodB(Sample[] samples)
		{
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i].S11MagOrRe = 20 * Math.Log10(samples[i].S11MagOrRe);
				samples[i].S12MagOrRe = 20 * Math.Log10(samples[i].S12MagOrRe);
				samples[i].S21MagOrRe = 20 * Math.Log10(samples[i].S21MagOrRe);
				samples[i].S22MagOrRe = 20 * Math.Log10(samples[i].S22MagOrRe);
			}

			return samples;
		}
	}
}
