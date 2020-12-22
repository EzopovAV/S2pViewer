using normalizerS2Pfiles.Enums;
using normalizerS2Pfiles.Interfaces;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using normalizerS2Pfiles.S2pProvider;

namespace normalizerS2Pfiles.Tests
{
	[TestFixture]
	class S2PProviderTests
	{
		[Test]
		[TestCase(typeof(DbS2PProvider))]
		[TestCase(typeof(MaS2PProvider))]
		[TestCase(typeof(RiS2PProvider))]
		public void GetSamplesHzTest(Type typeS2PProvider)
		{
			ConstructorInfo info = typeS2PProvider.GetConstructor(new[] { typeof(FrequencyUnits) });
			IS2PProvider s2PProvider = (IS2PProvider)info?.Invoke(new object[] { FrequencyUnits.Hz });

			var expectedResult = new[]
			{
				new Sample() { Freq = 4000000000 },
				new Sample() { Freq = 4010000000 },
				new Sample() { Freq = 4020000000 }
			};

			var actualResult = s2PProvider?.GetSamples(new[]
			{
				"# Hz S dB R 50",
				"4000000000	-3.644560e+001	-6.298539e+001	-1.595558e-001	-2.829229e-002	-1.909825e-001	2.051607e-001	-3.432156e+001	-4.708111e+001",
				"4010000000	-3.437424e+001	-8.516895e+001	-1.382003e-001	-1.922543e-002	-1.625682e-001	3.758700e-001	-3.353100e+001	-4.565454e+001",
				"4020000000	-3.581990e+001	-9.721659e+001	-1.931483e-001	1.249728e-001	-2.302538e-001	4.075333e-001	-3.387632e+001	-5.555784e+001",
			}).ToArray();

			double e = 0.001;

			for (int i = 0; i < 3; i++)
			{
				Assert.IsTrue(actualResult != null && Math.Abs(expectedResult[i].Freq - actualResult[i].Freq) < e);
			}
		}

		[Test]
		[TestCase(typeof(DbS2PProvider))]
		[TestCase(typeof(MaS2PProvider))]
		[TestCase(typeof(RiS2PProvider))]
		public void GetSampleskHzTest(Type typeS2PProvider)
		{
			ConstructorInfo info = typeS2PProvider.GetConstructor(new[] { typeof(FrequencyUnits) });
			IS2PProvider s2PProvider = (IS2PProvider)info?.Invoke(new object[] { FrequencyUnits.KHz });

			var expectedResult = new[]
			{
				new Sample() { Freq = 4000000000 },
				new Sample() { Freq = 4010000000 },
				new Sample() { Freq = 4020000000 }
			};

			var actualResult = s2PProvider?.GetSamples(new[]
			{
				"# kHz S dB R 50",
				"4000000	-3.644560e+001	-6.298539e+001	-1.595558e-001	-2.829229e-002	-1.909825e-001	2.051607e-001	-3.432156e+001	-4.708111e+001",
				"4010000	-3.437424e+001	-8.516895e+001	-1.382003e-001	-1.922543e-002	-1.625682e-001	3.758700e-001	-3.353100e+001	-4.565454e+001",
				"4020000	-3.581990e+001	-9.721659e+001	-1.931483e-001	1.249728e-001	-2.302538e-001	4.075333e-001	-3.387632e+001	-5.555784e+001",
			}).ToArray();

			double e = 0.001;

			for (int i = 0; i < 3; i++)
			{
				Assert.IsTrue(actualResult != null && Math.Abs(expectedResult[i].Freq - actualResult[i].Freq) < e);
			}
		}

		[Test]
		[TestCase(typeof(DbS2PProvider))]
		[TestCase(typeof(MaS2PProvider))]
		[TestCase(typeof(RiS2PProvider))]
		public void GetSamplesMHzTest(Type typeS2PProvider)
		{
			ConstructorInfo info = typeS2PProvider.GetConstructor(new[] { typeof(FrequencyUnits) });
			IS2PProvider s2PProvider = (IS2PProvider)info?.Invoke(new object[] { FrequencyUnits.MHz });

			var expectedResult = new[]
			{
				new Sample() { Freq = 4000000000 },
				new Sample() { Freq = 4010000000 },
				new Sample() { Freq = 4020000000 }
			};

			var actualResult = s2PProvider?.GetSamples(new[]
			{
				"# MHz S dB R 50",
				"4000	-3.644560e+001	-6.298539e+001	-1.595558e-001	-2.829229e-002	-1.909825e-001	2.051607e-001	-3.432156e+001	-4.708111e+001",
				"4010	-3.437424e+001	-8.516895e+001	-1.382003e-001	-1.922543e-002	-1.625682e-001	3.758700e-001	-3.353100e+001	-4.565454e+001",
				"4020	-3.581990e+001	-9.721659e+001	-1.931483e-001	1.249728e-001	-2.302538e-001	4.075333e-001	-3.387632e+001	-5.555784e+001",
			}).ToArray();

			double e = 0.001;

			for (int i = 0; i < 3; i++)
			{
				Assert.IsTrue(actualResult != null && Math.Abs(expectedResult[i].Freq - actualResult[i].Freq) < e);
			}
		}

		[Test]
		[TestCase(typeof(DbS2PProvider))]
		[TestCase(typeof(MaS2PProvider))]
		[TestCase(typeof(RiS2PProvider))]
		public void GetSamplesGHzTest(Type typeS2PProvider)
		{
			ConstructorInfo info = typeS2PProvider.GetConstructor(new[] { typeof(FrequencyUnits) });
			IS2PProvider s2PProvider = (IS2PProvider)info?.Invoke(new object[] { FrequencyUnits.GHz });

			var expectedResult = new[]
			{
				new Sample() { Freq = 4000000000 },
				new Sample() { Freq = 4010000000 },
				new Sample() { Freq = 4020000000 }
			};

			var actualResult = s2PProvider?.GetSamples(new[]
			{
				"# GHz S dB R 50",
				"4.000	-3.644560e+001	-6.298539e+001	-1.595558e-001	-2.829229e-002	-1.909825e-001	2.051607e-001	-3.432156e+001	-4.708111e+001",
				"4.010	-3.437424e+001	-8.516895e+001	-1.382003e-001	-1.922543e-002	-1.625682e-001	3.758700e-001	-3.353100e+001	-4.565454e+001",
				"4.020	-3.581990e+001	-9.721659e+001	-1.931483e-001	1.249728e-001	-2.302538e-001	4.075333e-001	-3.387632e+001	-5.555784e+001",
			}).ToArray();

			double e = 0.001;

			for (int i = 0; i < 3; i++)
			{
				Assert.IsTrue(actualResult != null && Math.Abs(expectedResult[i].Freq - actualResult[i].Freq) < e);
			}
		}

		[Test]
		public void GetSamplesDbTest()
		{
			var s2PProvider = new DbS2PProvider(FrequencyUnits.GHz);

			var expectedResult = new[]
			{
				new Sample() { Freq = 5000000000,
				S11MagOrRe = -45.9374, S11AngOrIm = 175.958,
				S12MagOrRe = -0.07453, S12AngOrIm = 87.0624,
				S21MagOrRe = -0.0745398, S21AngOrIm = 87.0624,
				S22MagOrRe = -45.9342, S22AngOrIm = 178.669 },

				new Sample() { Freq = 5010000000,
				S11MagOrRe = -45.9691, S11AngOrIm = 175.411,
				S12MagOrRe = -0.0745855, S12AngOrIm = 86.5163,
				S21MagOrRe = -0.0745953, S21AngOrIm = 86.5163,
				S22MagOrRe = -45.9658, S22AngOrIm = 178.142 },

				new Sample() { Freq = 5020000000,
				S11MagOrRe = -46.0029, S11AngOrIm = 174.865,
				S12MagOrRe = -0.0746467, S12AngOrIm = 85.9702,
				S21MagOrRe = -0.0746565, S21AngOrIm = 85.9702,
				S22MagOrRe = -45.9995, S22AngOrIm = 177.616 }
			};

			var actualResult = s2PProvider.GetSamples(new[]
			{
				"# GHZ S DB R 50",
				"5                       -45.9374         175.958         -0.07453         87.0624       -0.0745398         87.0624         -45.9342         178.669  ",
				"5.01                    -45.9691         175.411       -0.0745855         86.5163       -0.0745953         86.5163         -45.9658         178.142  ",
				"5.02                    -46.0029         174.865       -0.0746467         85.9702       -0.0746565         85.9702         -45.9995         177.616  ",
			}).ToArray();

			double e = 0.001;

			for (int i = 0; i < 3; i++)
			{
				Assert.IsTrue(CompareSamples(expectedResult[i], actualResult[i], e));
			}
		}
		
		[Test]
		public void GetSamplesMaTest()
		{
			var s2PProvider = new MaS2PProvider(FrequencyUnits.GHz);

			var expectedResult = new[]
			{
				new Sample() { Freq = 5000000000,
				S11MagOrRe = -45.9374, S11AngOrIm = 175.958,
				S12MagOrRe = -0.07453, S12AngOrIm = 87.0624,
				S21MagOrRe = -0.0745398, S21AngOrIm = 87.0624,
				S22MagOrRe = -45.9342, S22AngOrIm = 178.669 },

				new Sample() { Freq = 5010000000,
				S11MagOrRe = -45.9691, S11AngOrIm = 175.411,
				S12MagOrRe = -0.0745855, S12AngOrIm = 86.5163,
				S21MagOrRe = -0.0745953, S21AngOrIm = 86.5163,
				S22MagOrRe = -45.9658, S22AngOrIm = 178.142 },

				new Sample() { Freq = 5020000000,
				S11MagOrRe = -46.0029, S11AngOrIm = 174.865,
				S12MagOrRe = -0.0746467, S12AngOrIm = 85.9702,
				S21MagOrRe = -0.0746565, S21AngOrIm = 85.9702,
				S22MagOrRe = -45.9995, S22AngOrIm = 177.616 }
			};

			var actualResult = s2PProvider.GetSamples(new[]
			{
				"# GHZ S MA R 50",
				"5                     0.00504811         175.958         0.991456         87.0624         0.991455         87.0624       0.00504996         178.669  ",
				"5.01                  0.00502973         175.411          0.99145         86.5163         0.991449         86.5163       0.00503162         178.142  ",
				"5.02                  0.00501022         174.865         0.991443         85.9702         0.991442         85.9702       0.00501215         177.616  ",
			}).ToArray();

			double e = 0.001;

			for (int i = 0; i < 3; i++)
			{
				Assert.IsTrue(CompareSamples(expectedResult[i], actualResult[i], e));
			}
		}
		
		[Test]
		public void GetSamplesRiTest()
		{
			var s2PProvider = new RiS2PProvider(FrequencyUnits.GHz);

			var expectedResult = new[]
			{
				new Sample() { Freq = 5000000000,
				S11MagOrRe = -45.9374, S11AngOrIm = 175.958,
				S12MagOrRe = -0.07453, S12AngOrIm = 87.0624,
				S21MagOrRe = -0.0745398, S21AngOrIm = 87.0624,
				S22MagOrRe = -45.9342, S22AngOrIm = 178.669 },

				new Sample() { Freq = 5010000000,
				S11MagOrRe = -45.9691, S11AngOrIm = 175.411,
				S12MagOrRe = -0.0745855, S12AngOrIm = 86.5163,
				S21MagOrRe = -0.0745953, S21AngOrIm = 86.5163,
				S22MagOrRe = -45.9658, S22AngOrIm = 178.142 },

				new Sample() { Freq = 5020000000,
				S11MagOrRe = -46.0029, S11AngOrIm = 174.865,
				S12MagOrRe = -0.0746467, S12AngOrIm = 85.9702,
				S21MagOrRe = -0.0746565, S21AngOrIm = 85.9702,
				S22MagOrRe = -45.9995, S22AngOrIm = 177.616 }
			};

			var actualResult = s2PProvider.GetSamples(new[]
			{
				"# GHZ S RI R 50",
				"5                    -0.00503556      0.00035585        0.0508101        0.990153          0.05081        0.990152       -0.0050486       0.0001173  ",
				"5.01                 -0.00501361     0.000402384        0.0602447        0.989618        0.0602446        0.989617      -0.00502898     0.000163122  ",
				"5.02                 -0.00499011     0.000448436        0.0696738        0.988992        0.0696738         0.98899      -0.00500782     0.000208483  ",
			}).ToArray();

			double e = 0.001;

			for (int i = 0; i < 3; i++)
			{
				Assert.IsTrue(CompareSamples(expectedResult[i], actualResult[i], e));
			}
		}

		private bool CompareSamples(Sample firstSample, Sample secondSample, double e)
		{
			return Math.Abs(firstSample.Freq - secondSample.Freq) < e &&
			       Math.Abs(firstSample.S11MagOrRe - secondSample.S11MagOrRe) < e &&
			       Math.Abs(firstSample.S11AngOrIm - secondSample.S11AngOrIm) < e &&
			       Math.Abs(firstSample.S12MagOrRe - secondSample.S12MagOrRe) < e &&
			       Math.Abs(firstSample.S12AngOrIm - secondSample.S12AngOrIm) < e &&
			       Math.Abs(firstSample.S21MagOrRe - secondSample.S21MagOrRe) < e &&
			       Math.Abs(firstSample.S21AngOrIm - secondSample.S21AngOrIm) < e &&
			       Math.Abs(firstSample.S22MagOrRe - secondSample.S22MagOrRe) < e &&
			       Math.Abs(firstSample.S22AngOrIm - secondSample.S22AngOrIm) < e;
		}
	}
}
