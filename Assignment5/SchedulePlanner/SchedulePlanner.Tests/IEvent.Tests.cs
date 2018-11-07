using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentSix
{
    [TestClass]
    public class InterfaceEventTests
    {
        [TestMethod]
        public void CreateEvent_EventIsIEvent()
        {
            Event testEvent = new Event();

            Assert.IsTrue(testEvent is IEvent);
        }

        [TestMethod]
        public void CreateUniversityCourse_UniversityCourseIsIEvent()
        {
            UniversityCourse testUniversityCourse = new UniversityCourse();

            Assert.IsTrue(testUniversityCourse is IEvent);
        }

        [TestMethod]
        public void CreateScheduleItem_IEventIsNotImplementedClass()
        {
            IEvent testEvent = new Event();
            IEvent testUniversityCourse = new UniversityCourse();

            Assert.IsFalse(testEvent is UniversityCourse);
            Assert.IsFalse(testUniversityCourse is Event);
        }

        [TestMethod]
        public void CreateEvent_EventIsIEventAsEvent()
        {
            IEvent testEvent = new Event();
            Event testCastedEvent = testEvent as Event;

            Assert.IsTrue(testCastedEvent is Event);
        }

        [TestMethod]
        public void CreateUniversityCourse_UniversityCourseIsIEventAsUniversityCourse()
        {
            IEvent testUniversityCourse = new UniversityCourse();
            UniversityCourse testCastedUniversityCourse = testUniversityCourse as UniversityCourse;

            Assert.IsTrue(testCastedUniversityCourse is UniversityCourse);
        }

        [TestMethod]
        public void CreateEvent_EventIsIEventCastedToEvent()
        {
            IEvent testEvent = new Event();
            Event testCastedEvent = (Event) testEvent;

            Assert.IsTrue(testCastedEvent is Event);
        }

        [TestMethod]
        public void CreateUniversityCourse_UniversityCourseIsIEventCastedToUniversityCourse()
        {
            IEvent testUniversityCourse = new UniversityCourse();
            UniversityCourse testCastedUniversityCourse = (UniversityCourse) testUniversityCourse;

            Assert.IsTrue(testCastedUniversityCourse is UniversityCourse);
        }
    }
}