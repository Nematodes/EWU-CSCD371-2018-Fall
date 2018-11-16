using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentEight
{
    [TestClass]
    public class TimeTrackerDateTimeTests
    {
        private TimeTrackerDateTime TestTimeTrackerDateTime;

        [TestMethod]
        public void Constructor_ValidParameters_PropertiesAreSet()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);

            Assert.IsTrue(TestTimeTrackerDateTime.Hours == 2);
            Assert.IsTrue(TestTimeTrackerDateTime.Minutes == 5);
            Assert.IsTrue(TestTimeTrackerDateTime.Seconds == 24);
        }

        [TestMethod]
        public void ToString_ValidState_ReturnStringIsValid()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);

            Assert.IsTrue(TestTimeTrackerDateTime.ToString() == "2:05:24");
        }

        [TestMethod]
        public void SetHours_ValidParameter_HoursIsChanged()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);

            TestTimeTrackerDateTime.Hours = 5;

            Assert.IsTrue(TestTimeTrackerDateTime.Hours == 5);
        }

        [TestMethod]
        public void SetMinutes_ValidParameter_MinutesIsChanged()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);

            TestTimeTrackerDateTime.Minutes = 55;

            Assert.IsTrue(TestTimeTrackerDateTime.Minutes == 55);
        }

        [TestMethod]
        public void SetSeconds_ValidParameter_SecondsIsChanged()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);

            TestTimeTrackerDateTime.Seconds = 0;

            Assert.IsTrue(TestTimeTrackerDateTime.Seconds == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void SetHours_InvalidParameter_ArgumentOutOfRangeExceptionThrown()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);

            TestTimeTrackerDateTime.Hours = 24;
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void SetMinutes_InvalidParameter_ArgumentOutOfRangeExceptionThrown()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);

            TestTimeTrackerDateTime.Minutes = 650;
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void SetSeconds_InvalidParameter_ArgumentOutOfRangeExceptionThrown()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);

            TestTimeTrackerDateTime.Seconds = -1;
        }

        // No, I did not provide an Equals() override in TimeTrackerDateTime. If I did that, I would also have to override many other things with it!
        [TestMethod]
        public void Clone_ValidState_CloneIsEqual()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);

            TimeTrackerDateTime timeTrackerDateTimeClone = (TimeTrackerDateTime) TestTimeTrackerDateTime.Clone();

            Assert.IsTrue(TestTimeTrackerDateTime.Hours == timeTrackerDateTimeClone.Hours);
            Assert.IsTrue(TestTimeTrackerDateTime.Minutes == timeTrackerDateTimeClone.Minutes);
            Assert.IsTrue(TestTimeTrackerDateTime.Seconds == timeTrackerDateTimeClone.Seconds);
        }

        [TestMethod]
        public void Difference_ValidParameters_DifferenceIsCorrect()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);
            TimeTrackerDateTime subtrahendTimeTrackerDateTime = new TimeTrackerDateTime(1, 2, 3);
            TimeTrackerDateTime differenceTimeTrackerDateTime = (TimeTrackerDateTime) TestTimeTrackerDateTime.Difference(subtrahendTimeTrackerDateTime);

            Assert.IsTrue(differenceTimeTrackerDateTime.Hours == 1);
            Assert.IsTrue(differenceTimeTrackerDateTime.Minutes == 3);
            Assert.IsTrue(differenceTimeTrackerDateTime.Seconds == 21);
        }

        [TestMethod]
        public void Difference_ValidParametersWithCarryOver_DifferenceIsCorrect()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 0, 24);
            TimeTrackerDateTime subtrahendTimeTrackerDateTime = new TimeTrackerDateTime(1, 2, 34);
            TimeTrackerDateTime differenceTimeTrackerDateTime = (TimeTrackerDateTime)TestTimeTrackerDateTime.Difference(subtrahendTimeTrackerDateTime);

            Assert.IsTrue(differenceTimeTrackerDateTime.Hours == 0);
            Assert.IsTrue(differenceTimeTrackerDateTime.Minutes == 57);
            Assert.IsTrue(differenceTimeTrackerDateTime.Seconds == 50);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Difference_SubtrahendSmallerThanMinuend_ArgumentExceptionThrown()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);
            TimeTrackerDateTime subtrahendTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 25);
            TimeTrackerDateTime differenceTimeTrackerDateTime = (TimeTrackerDateTime)TestTimeTrackerDateTime.Difference(subtrahendTimeTrackerDateTime);
        }
    }
}
