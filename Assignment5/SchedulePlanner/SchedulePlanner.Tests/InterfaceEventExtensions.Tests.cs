using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BrianBosAssignmentFive
{
    [TestClass]
    public class InterfaceEventExtensionsTests
    {
        private IEvent FirstEvent { get; set; }
        private IEvent SecondEvent { get; set; }

        [TestMethod]
        public void SummaryLengthDifference_EqualLengthSummaries_ReturnsZero()
        {
            FirstEvent = new Event();
            SecondEvent = new Event();

            Assert.AreEqual(FirstEvent.SummaryLengthDifference(SecondEvent), 0);
        }

        [TestMethod]
        public void SummaryLengthDifference_DifferentSummaries_ReturnValueIsPositive()
        {
            FirstEvent = new Event("Munge Fuddler Exhibition", 2004, "Thursday, 17 Feb 2005");
            SecondEvent = new Event();

            Assert.IsTrue(FirstEvent.SummaryLengthDifference(SecondEvent) > 0);
        }

        [TestMethod]
        public void SummaryLengthDifference_ReverseDifferentSummaries_ReturnValueIsNegative()
        {
            FirstEvent = new Event("Munge Fuddler Exhibition", 2004, "Thursday, 17 Feb 2005");
            SecondEvent = new Event();

            Assert.IsTrue(SecondEvent.SummaryLengthDifference(FirstEvent) < 0);
        }
    }
}