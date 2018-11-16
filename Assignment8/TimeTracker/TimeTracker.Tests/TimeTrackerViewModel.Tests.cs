using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentEight
{
    [TestClass]
    public class TimeTrackerViewModelTests
    {
        private TimeTrackerViewModel TestTimeTrackerViewModel;
        private TestDateTime TestDateTimeInstance;

        public class TestDateTime : IDateTime
        {
            public int Hours { get; set; }

            public int Minutes { get; set; }

            public int Seconds { get; set; }

            public TestDateTime()
            {
                Hours = 1;
                Minutes = 2;
                Seconds = 3;
            }

            public object Clone()
            {
                return new TestDateTime();
            }

            public IDateTime Difference(IDateTime subtrahendTime)
            {
                return new TestDateTime();
            }

            public override string ToString()
            {
                return "<TestDateTime ToString() ReturnValue>";
            }
        }

        [TestInitialize]
        public void CreateTestTimeTrackerViewModel()
        {
            TestDateTimeInstance = new TestDateTime();
            TestTimeTrackerViewModel = new TimeTrackerViewModel(TestDateTimeInstance);
        }

        [TestMethod]
        public void Constructor_ValidParameters_DefaultPropertyValuesAreValid()
        {
            Assert.IsFalse(TestTimeTrackerViewModel.ElapsedTimeList is null);

            Assert.IsTrue(TestTimeTrackerViewModel.SelectedTimeDescriptionText == "No time entries are currently selected.");
            Assert.IsTrue(TestTimeTrackerViewModel.IsSelectedTimeDescriptionTextBoxEnabled == false);

            Assert.IsTrue(TestTimeTrackerViewModel.CurrentTimeText == $"Current time: <TestDateTime ToString() ReturnValue>");
            Assert.IsTrue(TestTimeTrackerViewModel.StartTimeText == "Start time: --:--:--");
            Assert.IsTrue(TestTimeTrackerViewModel.EndTimeText == "End time: --:--:--");

            Assert.IsTrue(TestTimeTrackerViewModel.TimerButtonText == "Start");
        }

        [TestMethod]
        public void OnDeleteEntryButtonClick_ItemIsSelected_ItemIsRemoved()
        {
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description"));
            TestTimeTrackerViewModel.ElapsedTimeListBoxSelectedIndex = 0;
            TestTimeTrackerViewModel.OnDeleteEntryButtonClick(null);

            Assert.IsTrue(TestTimeTrackerViewModel.ElapsedTimeList.Count == 0);
        }

        [TestMethod]
        public void SetCurrentTime_CurrentTimeIsSet()
        {
            TestTimeTrackerViewModel.CurrentTime = new TestDateTime();

            Assert.IsTrue(TestTimeTrackerViewModel.CurrentTime.Hours == 1);
            Assert.IsTrue(TestTimeTrackerViewModel.CurrentTime.Minutes == 2);
            Assert.IsTrue(TestTimeTrackerViewModel.CurrentTime.Seconds == 3);
        }

        [TestMethod]
        public void SetCurrentTimeText_CurrentTimeTextIsSet()
        {
            TestTimeTrackerViewModel.CurrentTimeText = "Test Text";

            Assert.IsTrue(TestTimeTrackerViewModel.CurrentTimeText == "Test Text");
        }

        [TestMethod]
        public void SetStartTime_StartTimeIsSet()
        {
            TestTimeTrackerViewModel.StartTime = new TestDateTime();

            Assert.IsTrue(TestTimeTrackerViewModel.StartTime.Hours == 1);
            Assert.IsTrue(TestTimeTrackerViewModel.StartTime.Minutes == 2);
            Assert.IsTrue(TestTimeTrackerViewModel.StartTime.Seconds == 3);
        }

        [TestMethod]
        public void SetStartTimeText_StartTimeTextIsSet()
        {
            TestTimeTrackerViewModel.StartTimeText = "Test Text";

            Assert.IsTrue(TestTimeTrackerViewModel.StartTimeText == "Test Text");
        }

        [TestMethod]
        public void SetEndTime_EndTimeIsSet()
        {
            TestTimeTrackerViewModel.EndTime = new TestDateTime();

            Assert.IsTrue(TestTimeTrackerViewModel.EndTime.Hours == 1);
            Assert.IsTrue(TestTimeTrackerViewModel.EndTime.Minutes == 2);
            Assert.IsTrue(TestTimeTrackerViewModel.EndTime.Seconds == 3);
        }

        [TestMethod]
        public void SetEndTimeText_EndTimeTextIsSet()
        {
            TestTimeTrackerViewModel.EndTimeText = "Test Text";

            Assert.IsTrue(TestTimeTrackerViewModel.EndTimeText == "Test Text");
        }

        // Effectively just showing that ElapsedTimeList accepts IDateTime instances
        [TestMethod]
        public void ElapsedTimeList_AddElements_ListCountIs2()
        {
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description"));
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description 2"));

            Assert.IsTrue(TestTimeTrackerViewModel.ElapsedTimeList.Count == 2);
        }

        [TestMethod]
        public void SetElapsedTimeListBoxSelectedIndex_ElapsedTimeListBoxSelectedIndexIsSet()
        {
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description"));
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description 2"));

            TestTimeTrackerViewModel.ElapsedTimeListBoxSelectedIndex = 1;

            Assert.IsTrue(TestTimeTrackerViewModel.ElapsedTimeListBoxSelectedIndex == 1);
        }

        [TestMethod]
        public void SetSelectedTimeDescriptionText_SelectedTimeDescriptionTextIsSet()
        {
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description"));
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description 2"));

            TestTimeTrackerViewModel.SelectedTimeDescriptionText = "Test String";

            Assert.IsTrue(TestTimeTrackerViewModel.SelectedTimeDescriptionText == "Test String");
        }

        [TestMethod]
        public void SetIsSelectedTimeDescriptionTextBoxEnabled_IsSelectedTimeDescriptionTextBoxEnabledIsSet()
        {
            TestTimeTrackerViewModel.IsSelectedTimeDescriptionTextBoxEnabled = true;

            Assert.IsTrue(TestTimeTrackerViewModel.IsSelectedTimeDescriptionTextBoxEnabled == true);
        }

        [TestMethod]
        public void SetTimerButtonText_TimerButtonTextIsSet()
        {
            TestTimeTrackerViewModel.TimerButtonText = "Test String";

            Assert.IsTrue(TestTimeTrackerViewModel.TimerButtonText == "Test String");
        }

        [TestMethod]
        public void OnDeleteEntryButtonClick_ItemIsNotSelected_ItemIsRemoved()
        {
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description"));
            TestTimeTrackerViewModel.ElapsedTimeListBoxSelectedIndex = -1;
            TestTimeTrackerViewModel.OnDeleteEntryButtonClick(null);

            Assert.IsTrue(TestTimeTrackerViewModel.ElapsedTimeList.Count == 1);
        }

        [TestMethod]
        public void OnListBoxItemSelect_ItemIsSelected_NewPropertyStateIsValid()
        {
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description"));
            TestTimeTrackerViewModel.ElapsedTimeListBoxSelectedIndex = 0;
            TestTimeTrackerViewModel.OnListBoxItemSelect();

            Assert.IsTrue(TestTimeTrackerViewModel.IsSelectedTimeDescriptionTextBoxEnabled == true);
            Assert.IsTrue(TestTimeTrackerViewModel.SelectedTimeDescriptionText == "Test Description");
        }

        [TestMethod]
        public void OnListBoxItemSelect_ItemIsNotSelected_NewPropertyStateIsValid()
        {
            TestTimeTrackerViewModel.ElapsedTimeList.Add(new ElapsedTimeModel(new TestDateTime(), "Test Description"));
            TestTimeTrackerViewModel.ElapsedTimeListBoxSelectedIndex = -1;
            TestTimeTrackerViewModel.OnListBoxItemSelect();

            Assert.IsTrue(TestTimeTrackerViewModel.IsSelectedTimeDescriptionTextBoxEnabled == false);
            Assert.IsTrue(TestTimeTrackerViewModel.SelectedTimeDescriptionText == "No time entries are currently selected.");
        }

        /*
         * Testing CurrentTime is not feasible due to its nature (i.e. getting the current time, which may fail a check very rarely.)
         * Since CurrentTime cannot be properly tested, StartTime and EndTime cannot properly be tested either.
         */
        [TestMethod]
        public void OnTimerButtonClick_StartState_StateIsStop()
        {
            TestTimeTrackerViewModel.OnTimerButtonClick(null);

            Assert.IsTrue(TestTimeTrackerViewModel.StartTimeText == "Start time: <TestDateTime ToString() ReturnValue>");
            Assert.IsTrue(TestTimeTrackerViewModel.EndTimeText == "End time: --:--:--");
            Assert.IsTrue(TestTimeTrackerViewModel.TimerButtonText == "Stop");
        }

        [TestMethod]
        public void OnTimerButtonClick_StopState_StateIsStart()
        {
            TestTimeTrackerViewModel.TimerButtonText = "Stop";
            TestTimeTrackerViewModel.OnTimerButtonClick(null);

            Assert.IsTrue(TestTimeTrackerViewModel.EndTimeText == "End time: <TestDateTime ToString() ReturnValue>");
            Assert.IsTrue(TestTimeTrackerViewModel.TimerButtonText == "Start");
        }

        [TestMethod]
        public void CurrentTimeUpdate_DontCareParameters_CurrentTimeTextIsValid()
        {
            TestTimeTrackerViewModel.CurrentTimeUpdate(null, null);

            Assert.IsTrue(TestTimeTrackerViewModel.CurrentTimeText == "Current time: <TestDateTime ToString() ReturnValue>");
        }
    }
}