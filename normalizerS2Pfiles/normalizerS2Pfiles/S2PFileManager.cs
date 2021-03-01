using normalizerS2Pfiles.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace normalizerS2Pfiles
{
	public class S2PFileManager
	{
		private readonly string _s2PFileName;
		private readonly IS2PReader _s2PReader;
		private readonly IS2PProviderFactory _s2PProviderFactory;

		public S2PFileManager(string s2PFileName, IS2PReader s2PReader, IS2PProviderFactory s2PProviderFactory)
		{
			if (string.IsNullOrEmpty(s2PFileName))
			{
				throw new ArgumentException("s2pFileName can't be null or empty");
			}
			_s2PFileName = s2PFileName;

			_s2PReader = s2PReader ?? throw new ArgumentNullException(nameof(s2PReader));

			_s2PProviderFactory = s2PProviderFactory ?? throw new ArgumentNullException(nameof(s2PProviderFactory));
		}

		public string NormalizeToFile(string destinationPath)
		{
			try
			{
				string[] source = File.ReadAllLines(_s2PFileName);

				var format = _s2PReader.GetFormat(source);

				var provider = _s2PProviderFactory.GetS2PProvider(format);

				string[] result = provider.GetNormalizedS2P(source);

				File.WriteAllLines(destinationPath, result);
			}
			catch (Exception e)
			{

				return "Error:/n" + e;
			}

			return "File normalized successfully.";
		}

		public IEnumerable<Sample> GetSamples()
		{
			try
			{
				string[] source = File.ReadAllLines(_s2PFileName);

				var format = _s2PReader.GetFormat(source);

				var provider = _s2PProviderFactory.GetS2PProvider(format);

				var result = provider.GetSamples(source);

				return result;
			}
			catch (Exception e)
			{
				return null;
			}
		}
	}
}
