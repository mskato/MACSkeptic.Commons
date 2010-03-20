using System;
using System.Collections;
using System.Collections.Generic;
using MACSkeptic.ExpLorer.Utils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MACSkeptic.ExpLorer.Tests.Utils.Extensions
{
    [TestClass]
    public class EnumerableExtensionsTest
    {
        [TestMethod]
        public void ShouldExecuteForEachOnANonEmptyList()
        {
            var counter = 0;
            var action = new Action<string>(x => counter++);
            new[] {"macskeptic", ";)"}.ExecuteForEach(action);
            Assert.AreEqual(2, counter);
        }

        [TestMethod]
        public void ShouldNeverExecuteOnAnEmptyList()
        {
            var counter = 0;
            var action = new Action<string>(x => counter++);
            new string[] {}.ExecuteForEach(action);
            Assert.AreEqual(0, counter);
        }

        [TestMethod]
        public void ShouldConsiderAnEmptyListToBeEmpty()
        {
            Assert.IsTrue(new List<string>().IsEmpty());
        }

        [TestMethod]
        public void ShouldConsiderANullListToBeEmpty()
        {
            Assert.IsTrue(((IEnumerable)null).IsEmpty());
        }

        [TestMethod]
        public void ShouldNotConsiderAPopulatedListToBeEmpty()
        {
            Assert.IsFalse(new[] {"macskeptic"}.IsEmpty());
        }

        [TestMethod]
        public void ShouldJoinAsStringGivenASeparator()
        {
            Assert.AreEqual("macskeptic, ;), !", new[] {"macskeptic", ";)", "!"}.JoinAsString(", "));
        }

        [TestMethod]
        public void ShouldJoinAsStringGivenASeparatorAppendingANewLineForEachElement()
        {
            const string expected = @"macskeptic,
;),
!";

            Assert.AreEqual(expected, new[] {"macskeptic", ";)", "!"}.JoinAsString(",", true));
        }
    }
}