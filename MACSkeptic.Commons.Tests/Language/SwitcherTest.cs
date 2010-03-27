using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MACSkeptic.Commons.Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MACSkeptic.Commons.Tests.Language
{
    [TestClass]
    public class SwitcherTest
    {
        [TestMethod]
        public void ShouldSwitchAccordinglyToTargetValue()
        {
            var switcher = new Switcher<string, long>();
            Assert.AreEqual(3, switcher
                .When("the answer to life, universe, everything").Do(() => 42)
                .When("round(pi)").Do(() => 3)
                .Default().Do(() => 0)
                .ConsiderThisCase("round(pi)"));
        }

        [TestMethod]
        public void ShouldGoForTheDefaultCase()
        {
            var switcher = new Switcher<string, long>();
            Assert.AreEqual(550, switcher
                .When("the answer to life, universe, everything").Do(() => 42)
                .When("round(pi)").Do(() => 3)
                .Default().Do(() => 550)
                .ConsiderThisCase("ansdasd"));
        }
    }
}
