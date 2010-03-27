using System.Collections;
using System.Collections.Generic;
using MACSkeptic.Commons.Expectations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MACSkeptic.Commons.Tests
{
    [TestClass]
    public class SpinOff
    {
        [TestMethod]
        public void X()
        {
            Assert.IsTrue("asdasd".ShouldNot().BeNull());
            Assert.IsTrue("asdasd".ShouldNot().BeEmpty());
            Assert.IsTrue("asdasd".Should().BeTheSameAs("asdasd"));
            Assert.IsTrue("asdasd".ShouldNot().BeTheSameAs("asdasd2"));
            Assert.IsTrue("".Should().BeEmpty());
            Assert.IsTrue("".Should().BeAnInstanceOf(typeof (object)));
            Assert.IsTrue(new[] {false}.ShouldNot<IEnumerable>().BeEmpty());
            Assert.IsTrue(new int[0].Should<IEnumerable>().BeEmpty());
            Assert.IsTrue(new int[0].Should<IEnumerable>().BeAnInstanceOf(typeof (IEnumerable)));
            Assert.IsTrue(new int[0].Should<IEnumerable<int>>().BeAnInstanceOf(typeof (IEnumerable)));
        }
    }
}