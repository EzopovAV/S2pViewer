using System.Collections.Generic;

namespace normalizerS2Pfiles.Interfaces
{
	public interface IS2PProvider
	{
		/// <summary>
		/// Return all samples normalized to format # Hz S dB R 50
		/// </summary>
		/// <returns></returns>
		IEnumerable<Sample> GetSamples(string[] source);

		/// <summary>
		/// Return all data normalized to format # Hz S dB R 50
		/// </summary>
		/// <returns></returns>
		string[] GetNormalizedS2P(string[] source);
	}
}
