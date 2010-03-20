using MACSkeptic.ExpLorer.Utils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MACSkeptic.ExpLorer.Tests.Utils.Extensions
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void ShouldProperlyApplyArgumentsToAString()
        {
            Assert.AreEqual("macskeptic ;)!", "macskeptic #{wink}#{bang}".ApplyArguments(new {wink = ";)", bang = "!"}));
        }

        [TestMethod]
        public void EmptyStringShouldBeEmpty()
        {
            Assert.IsTrue(string.Empty.IsEmpty());
        }

        [TestMethod]
        public void NullStringShouldBeEmpty()
        {
            Assert.IsTrue(((string)null).IsEmpty());
        }

        [TestMethod]
        public void NonEmptyStringIsNotEmpty()
        {
            Assert.IsFalse("macskeptic".IsEmpty());
        }
    }
}