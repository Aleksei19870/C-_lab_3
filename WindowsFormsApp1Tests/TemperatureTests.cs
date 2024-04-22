using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class TemperatureTests
    {

        [TestMethod()]
        public void VerboseTest()
        {
            var Temperature = new Temperature(10, MeasureType.C);
            Assert.AreEqual("10 C", Temperature.Verbose());

            Temperature = new Temperature(38, MeasureType.F);
            Assert.AreEqual("38 F", Temperature.Verbose());

            Temperature = new Temperature(28, MeasureType.R);
            Assert.AreEqual("28 R", Temperature.Verbose());

            Temperature = new Temperature(18, MeasureType.K);
            Assert.AreEqual("18 K", Temperature.Verbose());
        }

        [TestMethod()]
        public void AddNumberTest()
        {
            var length = new Temperature(1, MeasureType.C);
            length = length + 4.25;
            Assert.AreEqual("5,25 C", length.Verbose());
        }

        [TestMethod()]
        public void SubNumberTest()
        {
            var length = new Temperature(3, MeasureType.F);
            length = length - 1.75;
            Assert.AreEqual("1,25 F", length.Verbose());
        }

        [TestMethod()]
        public void MulByNumberTest()
        {
            var length = new Temperature(3, MeasureType.R);
            length = length * 3;
            Assert.AreEqual("9 R", length.Verbose());
        }

        [TestMethod()]
        public void DivByNumberTest()
        {
            var length = new Temperature(3, MeasureType.K);
            length = length / 3;
            Assert.AreEqual("1 K", length.Verbose());
        }

        [TestMethod()]
        public void MeterToAnyTest()
        {
            Temperature length;

            length = new Temperature(0, MeasureType.C);
            Assert.AreEqual("32 F", length.To(MeasureType.F).Verbose());

            length = new Temperature(0, MeasureType.C);
            Assert.AreEqual("491,67 R", length.To(MeasureType.R).Verbose());

            length = new Temperature(-272.15, MeasureType.C);
            Assert.AreEqual("1 K", length.To(MeasureType.K).Verbose());
        }

        [TestMethod()]
        public void AnyToMeterTest()
        {
            Temperature length;

            length = new Temperature(1, MeasureType.F);
            Assert.AreEqual("-17,2222222222222 C", length.To(MeasureType.C).Verbose());

            length = new Temperature(1, MeasureType.R);
            Assert.AreEqual("-272,594444444444 C", length.To(MeasureType.C).Verbose());

            length = new Temperature(1, MeasureType.K);
            Assert.AreEqual("-272,15 C", length.To(MeasureType.C).Verbose());
        }

        [TestMethod()]
        public void AddSubKmMetersTest()
        {
            var C = new Temperature(100, MeasureType.C);
            var K = new Temperature(1, MeasureType.K);

            Assert.AreEqual("-172,15 C", (C + K).Verbose());
            Assert.AreEqual("374,15 K", (K + C).Verbose());

            Assert.AreEqual("-372,15 K", (K - C).Verbose());
            Assert.AreEqual("372,15 C", (C - K).Verbose());
        }
    }
}