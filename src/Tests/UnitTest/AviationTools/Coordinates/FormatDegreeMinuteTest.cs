﻿using NUnit.Framework;
using static QSP.AviationTools.Coordinates.FormatDegreeMinute;

namespace UnitTest.AviationTools.Coordinates
{
    [TestFixture]
    public class FormatDegreeMinuteTest
    {
        [Test]
        public void CustomFormatTest()
        {
            var result = ToDegreeMinuteFormat(25.073133333, "F2");
            Assert.IsTrue("25° 4.39'" == result);
        }
    }
}
