using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentEight
{
    [TestClass]
    public class ElapsedTimeModelTests
    {
        private ElapsedTimeModel TestElapsedTimeModel;
        private TimeTrackerDateTime TestTimeTrackerDateTime;

        [TestMethod]
        public void Constructor_ValidParameters_PropertiesAreSet()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);
            TestElapsedTimeModel = new ElapsedTimeModel(TestTimeTrackerDateTime, "Test Description");

            Assert.IsTrue(TestElapsedTimeModel.ElapsedTime == TestTimeTrackerDateTime);
            Assert.IsTrue(TestElapsedTimeModel.Description == "Test Description");
        }

        [TestMethod]
        public void Constructor_ValidParameters_ElapsedTimeStringReturnsToString()
        {
            TestTimeTrackerDateTime = new TimeTrackerDateTime(2, 5, 24);
            TestElapsedTimeModel = new ElapsedTimeModel(TestTimeTrackerDateTime, "Test Description");

            Assert.IsTrue(TestElapsedTimeModel.ElapsedTimeString == TestElapsedTimeModel.ElapsedTime.ToString());
        }
    }
}
