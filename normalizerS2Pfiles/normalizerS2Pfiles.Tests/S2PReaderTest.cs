﻿using normalizerS2Pfiles.Enums;
using normalizerS2Pfiles.Interfaces;
using NUnit.Framework;
using System;

namespace normalizerS2Pfiles.Tests
{
    [TestFixture]
    public class S2PReaderTest
    {
        private IS2PReader _s2PReader;

        [SetUp]
        public void SetUp()
        {
            _s2PReader = new S2PReader();
        }

        [Test]
        [TestCase(new[] { "# Hz S dB R 50", }, DataUnits.Db, FrequencyUnits.Hz)]
        [TestCase(new[] { "# Hz S dB R 50", "", }, DataUnits.Db, FrequencyUnits.Hz)]
        [TestCase(new[] { "", "# Hz S dB R 50", }, DataUnits.Db, FrequencyUnits.Hz)]
        [TestCase(new[] { "# MHz S MA R 50", }, DataUnits.Ma, FrequencyUnits.MHz)]
        [TestCase(new[] { "# GHz S RI R 50", }, DataUnits.Ri, FrequencyUnits.GHz)]

        [TestCase(new[]
            {
                "!Agilent Technologies,E5071B,MY42404614,A.06.51",
                "!Date: Thu Jul 31 15:18:06 2014",
                "!Data & Calibration Information:",
                "!Freq   S11: SOLT2(ON)   S21: SOLT2(ON)   S12: SOLT2(ON)   S22: SOLT2(ON)",
                "# Hz S dB R 50",
                "4000000000	-3.644560e+001	-6.298539e+001	-1.595558e-001	-2.829229e-002	-1.909825e-001	2.051607e-001	-3.432156e+001	-4.708111e+001",
                "4010000000	-3.437424e+001	-8.516895e+001	-1.382003e-001	-1.922543e-002	-1.625682e-001	3.758700e-001	-3.353100e+001	-4.565454e+001",
                "4020000000	-3.581990e+001	-9.721659e+001	-1.931483e-001	1.249728e-001	-2.302538e-001	4.075333e-001	-3.387632e+001	-5.555784e+001",
            },
            DataUnits.Db, FrequencyUnits.Hz)]

        [TestCase(new[]
            {
                "#  HZ   S   DB   R     50.00 ",
                "! Rohde & Schwarz ZVA40 4Ports - Version 3.60 - 1145.1110k42 SN: 100347",
                "! Date: 2016-12-01 06:21:32",
                "! Measurements: S11 S21 S12 S22",
                "!",
                " 1.000000000000000E8    -8.364428183976352E-1  -1.511865964239428E1  -4.490380553611293E1  -1.137295779836928E2  -3.194473490728180E1  -7.440342849466386E1   4.325570246656326   2.378441860772131E1",
                " 1.124375000000000E8    -2.967521509468283E-1  -1.857903983376380E1  -4.268604469573422E1   1.175119218257896E2  -3.629034076435700E1   4.102135566868948E1  -1.249042959198563E1  -1.959582144778481",
                " 1.248750000000000E8     6.242534483751702E-2  -1.769720983031905E1  -4.053703733423642E1  -1.250203124265302E2  -5.074205524202499E1  -1.341899860338712E2   4.538911623398153  -1.014600560810642E2",
            },
            DataUnits.Db, FrequencyUnits.Hz)]

        [TestCase(new[]
            {
                @"! TOUCHSTONE file generated by CST MICROWAVE STUDIO",
                @"! Date and time: Tue Apr 24 13:55:47 2018",
                @"! Project name: Test_Line_20170724.cst",
                @"! Header version: 2015",
                @"! Port assignment regex: !\s*Touchstone port\s*([0-9]+)\s*=\s*CST MWS port\s*([0-9]+)\s*\(\""(.*)\""\)(\s*mode\s*([0-9]+))?.*",
                @"! Touchstone port assignment:",
                @"! Touchstone port 1 = CST MWS port 1 ("")",
                @"! Touchstone port 2 = CST MWS port 2 ("")",
                @"# GHZ S MA R 50",
                @"5                     0.00504811         175.958         0.991456         87.0624         0.991455         87.0624       0.00504996         178.669",
                @"5.01                  0.00502973         175.411          0.99145         86.5163         0.991449         86.5163       0.00503162         178.142",
                @"5.02                  0.00501022         174.865         0.991443         85.9702         0.991442         85.9702       0.00501215         177.616",
            },
            DataUnits.Ma, FrequencyUnits.GHz)]

        [TestCase(new[]
            {
                "! Created Tue Apr 24 14:53:30 2018",
                "# hz S ma R 50",
                "! 2 Port Network Data from data block",
                "! freq  magS11  angS11  magS21  angS21  magS12  angS12  magS22  angS22",
                "!",
                "                 0     0.00108007226                  0        0.998919928                  0        0.998919928                  0      0.00108007226                  0",
                "          56000000      0.0360280772        -91.5215225        0.997787567         -4.0061524        0.997787567         -4.0061524        0.036027861        -91.5228249",
                "         112000000      0.0720417817        -96.5671751        0.995594684        -7.99609258        0.995594684        -7.99609258       0.0720412564        -96.5696114",
            },
            DataUnits.Ma, FrequencyUnits.Hz)]

        [TestCase(new[]
            {
                "! Created Tue Apr 24 14:54:15 2018",
                "# mhz S ri R 50",
                "! 2 Port Network Data from data block",
                "! freq  reS11  imS11  reS21  imS21  reS12  imS12  reS22  imS22",
                "!",
                "                 0     0.00108007226                 -0        0.998919928                 -0        0.998919928                 -0      0.00108007226                 -0",
                "                56   -0.000956633912      -0.0360153745        0.995349527       -0.069709023        0.995349527       -0.069709023    -0.000957446895      -0.0360151366",
                "               112    -0.00823927638       -0.071569076        0.985915072       -0.138492763        0.985915072       -0.138492763     -0.00824225941      -0.0715682037",
            },
            DataUnits.Ri, FrequencyUnits.MHz)]

        public void GetFormatTest(string[] source, DataUnits dataUnits, FrequencyUnits frequencyUnits)
        {
            S2PFormat expectedFormat = new S2PFormat { DataUnits = dataUnits, FrequencyUnits = frequencyUnits };
            S2PFormat actualFormat = _s2PReader.GetFormat(source);
            Assert.AreEqual(expectedFormat, actualFormat);
        }

        [Test]
        [TestCase("")]
        [TestCase("# THz S dB R 50")]
        [TestCase("! Hz S dB R 50")]
        [TestCase("# Hz S Volt R 50")]
        public void GetFormatExceptionTest(string formatString)
        {
            string[] source = new string[] { formatString, };
            Assert.Throws<Exception>(() => _s2PReader.GetFormat(source));
        }

        [Test]
        public void GetFormatSourceNullTest()
        {
            Assert.Throws<NullReferenceException>(() => _s2PReader.GetFormat(null));
        }
    }
}
