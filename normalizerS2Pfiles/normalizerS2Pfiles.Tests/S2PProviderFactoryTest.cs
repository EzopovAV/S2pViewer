using System;
using normalizerS2Pfiles.Enums;
using normalizerS2Pfiles.Interfaces;
using normalizerS2Pfiles.S2pProvider;
using NUnit.Framework;

namespace normalizerS2Pfiles.Tests
{
	[TestFixture]
	class S2PProviderFactoryTest
	{
		private IS2PProviderFactory _s2PProviderFactory;

		[SetUp]
		public void SetUp()
		{
			_s2PProviderFactory = new S2PProviderFactory();
		}

		[Test]
		[TestCase(DataUnits.Db, typeof(DbS2PProvider))]
		[TestCase(DataUnits.Ma, typeof(MaS2PProvider))]
		[TestCase(DataUnits.Ri, typeof(RiS2PProvider))]

		public void GetS2PProviderTest(DataUnits dataUnits, Type expectedTypeProvider)
		{
			var s2PFormat = new S2PFormat { DataUnits = dataUnits };
			var actualProvider = _s2PProviderFactory.GetS2PProvider(s2PFormat);
			Assert.AreEqual(expectedTypeProvider, actualProvider.GetType());
		}

		[Test]
		public void GetS2PProviderUnsupportedDataFormatTest()
		{
			var s2PFormat = new S2PFormat();
			s2PFormat.DataUnits = (DataUnits)int.MaxValue;
			Assert.Throws<Exception>(() => _s2PProviderFactory.GetS2PProvider(s2PFormat));
		}

		[Test]
		public void GetS2PProviderNullTest()
		{
			Assert.Throws<NullReferenceException>(() => _s2PProviderFactory.GetS2PProvider(null));
		}
	}
}
