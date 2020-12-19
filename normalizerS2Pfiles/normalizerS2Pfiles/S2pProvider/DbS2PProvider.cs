using normalizerS2Pfiles.Enums;

namespace normalizerS2Pfiles.S2pProvider
{
	public class DbS2PProvider : BaseS2PProvider
	{
		public DbS2PProvider(FrequencyUnits frequencyUnits)
			:base(frequencyUnits)
		{
		}

		protected override Sample[] ConvertDataTodB(Sample[] samples)
		{
			return samples;
		}
	}
}
