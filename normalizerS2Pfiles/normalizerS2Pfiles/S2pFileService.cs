using System.Collections.Generic;

namespace normalizerS2Pfiles
{
	public class S2pFileService
	{
		private readonly string _fullPathS2pFile;
		public S2pFileService(string fullPathS2pFile)
		{
			_fullPathS2pFile = fullPathS2pFile;
		}
		public IEnumerable<Sample> GetSamples()
		{
			var s2PFileManager = new S2PFileManager(_fullPathS2pFile, new S2PReader(), new S2PProviderFactory());
			return s2PFileManager.GetSamples();
		}
	}
}
