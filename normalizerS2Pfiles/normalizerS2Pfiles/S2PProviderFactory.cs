using normalizerS2Pfiles.Enums;
using normalizerS2Pfiles.Interfaces;
using System;
using normalizerS2Pfiles.S2pProvider;

namespace normalizerS2Pfiles
{
	public class S2PProviderFactory : IS2PProviderFactory
	{
		public IS2PProvider GetS2PProvider(S2PFormat format)
		{
			switch (format.DataUnits)
			{
				case DataUnits.Db:
						return new DbS2PProvider(format.FrequencyUnits);

				case DataUnits.Ma:
						return new MaS2PProvider(format.FrequencyUnits);
				
				case DataUnits.Ri:
						return new RiS2PProvider(format.FrequencyUnits);
				
				default:
						throw new Exception("Unsupported data format");
			}
		}
	}
}
