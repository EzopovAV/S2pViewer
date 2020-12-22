using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using normalizerS2Pfiles.Enums;
using normalizerS2Pfiles.Interfaces;

namespace normalizerS2Pfiles.S2pProvider
{
	public abstract class BaseS2PProvider : IS2PProvider
	{
		private readonly FrequencyUnits _frequencyUnits;

		public BaseS2PProvider(FrequencyUnits frequencyUnits)
		{
			_frequencyUnits = frequencyUnits;
		}

		public string[] GetNormalizedS2P(string[] source)
		{
			var samples = PrepareSamples(source);

			string[] commentStrings = source.Where(t => t.StartsWith("!")).ToArray();

			string[] result = new string[1 + commentStrings.Length + 1 + samples.Length];
			int i = 0;

			result[i] = "! This file was normalized.";
			i++;

			foreach (var item in commentStrings)
			{
				result[i] = item;
				i++;
			}

			result[i] = "# Hz S dB R 50";
			i++;

			foreach (var item in samples)
			{
				result[i] = item.Freq + "\t" +
					item.S11MagOrRe.ToString("E") + "\t" +
					item.S11AngOrIm.ToString("E") + "\t" +
					item.S12MagOrRe.ToString("E") + "\t" +
					item.S12AngOrIm.ToString("E") + "\t" +
					item.S21MagOrRe.ToString("E") + "\t" +
					item.S21AngOrIm.ToString("E") + "\t" +
					item.S22MagOrRe.ToString("E") + "\t" +
					item.S22AngOrIm.ToString("E");
				i++;
			}

			return result;
		}

		public IEnumerable<Sample> GetSamples(string[] source)
		{
			return PrepareSamples(source);
		}

		private Sample[] PrepareSamples(string[] source)
		{
			var sampleStrings = source.Where(t => !t.StartsWith("!") && !t.StartsWith("#")).ToArray();

			var samples = ParseSample(sampleStrings);

			samples = ConvertFreqToHz(_frequencyUnits, samples);

			samples = ConvertDataTodB(samples);
			return samples;
		}

		private Sample[] ParseSample(string[] sampleStrings)
		{
			var samples = new Sample[sampleStrings.Length];

			string[] sampleString;
			for (int i = 0; i < samples.Length; i++)
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

				sampleString = sampleStrings[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

				try
				{
					samples[i].Freq = Double.Parse(sampleString[0]);
					samples[i].S11MagOrRe = Double.Parse(sampleString[1]);
					samples[i].S11AngOrIm = Double.Parse(sampleString[2]);
					samples[i].S12MagOrRe = Double.Parse(sampleString[3]);
					samples[i].S12AngOrIm = Double.Parse(sampleString[4]);
					samples[i].S21MagOrRe = Double.Parse(sampleString[5]);
					samples[i].S21AngOrIm = Double.Parse(sampleString[6]);
					samples[i].S22MagOrRe = Double.Parse(sampleString[7]);
					samples[i].S22AngOrIm = Double.Parse(sampleString[8]);
				}
				catch (Exception)
				{
					throw new Exception("Invalid data.");
				}
			}

			return samples;
		}

		private Sample[] ConvertFreqToHz(FrequencyUnits frequencyUnits, Sample[] samples)
		{
			Func<double, double> func;

			switch (frequencyUnits)
			{
				case FrequencyUnits.Hz:
					return samples;

				case FrequencyUnits.KHz:
					func = f => f * 1E3;
					break;

				case FrequencyUnits.MHz:
					func = f => f * 1E6;
					break;

				case FrequencyUnits.GHz:
					func = f => f * 1E9;
					break;

				default:
					throw new Exception("Unsupported frequency units");
			}

			return ConvertFreq(samples, func);
		}

		private Sample[] ConvertFreq(Sample[] samples, Func<double, double> func)
		{
			for (int i = 0; i < samples.Length; i++)
			{
				samples[i].Freq = func(samples[i].Freq);
			}
			return samples;
		}

		protected abstract Sample[] ConvertDataTodB(Sample[] samples);
	}
}
