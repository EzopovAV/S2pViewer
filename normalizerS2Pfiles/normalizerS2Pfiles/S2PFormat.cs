using normalizerS2Pfiles.Enums;

namespace normalizerS2Pfiles
{
	public class S2PFormat
	{
		public FrequencyUnits FrequencyUnits;
		public DataUnits DataUnits;

		public bool Equals(S2PFormat other)
		{
			if (ReferenceEquals(this, other))
			{
				return true;
			}

			if (ReferenceEquals(other, null))
			{
				return false;
			}

			return FrequencyUnits == other.FrequencyUnits && DataUnits == other.DataUnits;
		}

		public override bool Equals(object obj)
		{
			S2PFormat s2PFormat = obj as S2PFormat;
			return Equals(s2PFormat);
		}

		public override int GetHashCode()
		{
			return FrequencyUnits.GetHashCode() ^ DataUnits.GetHashCode();
		}
	}
}
