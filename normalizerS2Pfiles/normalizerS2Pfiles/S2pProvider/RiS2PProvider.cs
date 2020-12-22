using System;
using normalizerS2Pfiles.Enums;

namespace normalizerS2Pfiles.S2pProvider
{
	public class RiS2PProvider : BaseS2PProvider
	{
		public RiS2PProvider(FrequencyUnits frequencyUnits)
			: base(frequencyUnits)
		{
		}

		protected override Sample[] ConvertDataTodB(Sample[] samples)
		{
			//Sample sample = new Sample(); // ?

			for (int i = 0; i < samples.Length; i++)
			{
				Sample sample = samples[i];

				samples[i].S11MagOrRe = 20 * Math.Log10(Math.Sqrt(Math.Pow(sample.S11MagOrRe, 2) + Math.Pow(sample.S11AngOrIm, 2)));
				samples[i].S11AngOrIm = 180 * Math.Atan2(sample.S11AngOrIm, sample.S11MagOrRe) / Math.PI;

				samples[i].S12MagOrRe = 20 * Math.Log10(Math.Sqrt(Math.Pow(sample.S12MagOrRe, 2) + Math.Pow(sample.S12AngOrIm, 2)));
				samples[i].S12AngOrIm = 180 * Math.Atan2(sample.S12AngOrIm, sample.S12MagOrRe) / Math.PI;

				samples[i].S21MagOrRe = 20 * Math.Log10(Math.Sqrt(Math.Pow(sample.S21MagOrRe, 2) + Math.Pow(sample.S21AngOrIm, 2)));
				samples[i].S21AngOrIm = 180 * Math.Atan2(sample.S21AngOrIm, sample.S21MagOrRe) / Math.PI;

				samples[i].S22MagOrRe = 20 * Math.Log10(Math.Sqrt(Math.Pow(sample.S22MagOrRe, 2) + Math.Pow(sample.S22AngOrIm, 2)));
				samples[i].S22AngOrIm = 180 * Math.Atan2(sample.S22AngOrIm, sample.S22MagOrRe) / Math.PI;
			}

			return samples;
		}
	}
}
