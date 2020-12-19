using System;

namespace normalizerS2Pfiles
{
	class Program
	{
		static void Main()
		{
			string pathSource = @"..\..\..\s2p files\E5071B GPPM-_Chanel-1_Rx_ATTen-0_PHase-2.s2p";
			string pathResult = @"..\..\..\s2p files\E5071B GPPM-_Chanel-1_Rx_ATTen-0_PHase-2_nomalized.s2p";
			//pathSource = @"..\..\..\s2p files\ADS_Re.s2p";
			//pathResult = @"..\..\..\s2p files\ADS_Re.s2p_nomalized.s2p";

			var s2PFileManager = new S2PFileManager(pathSource, new S2PReader(), new S2PProviderFactory());
			var result = s2PFileManager.NormalizeToFile(pathResult);
			Console.WriteLine(result);

			Console.ReadLine();
		}
	}
}
