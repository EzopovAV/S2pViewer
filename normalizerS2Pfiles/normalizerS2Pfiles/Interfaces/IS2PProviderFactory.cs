namespace normalizerS2Pfiles.Interfaces
{
	public interface IS2PProviderFactory
	{
		IS2PProvider GetS2PProvider(S2PFormat format);
	}
}
