using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BrianBosAssignment4Namespace
{
    [TestClass]
    public class SummarizerTests
    {
        [TestMethod]
        public void DisplayObjectSummary_UniversityCourse_SummaryIsValid()
        {
            UniversityCourse testUniversityCourse = new UniversityCourse(".NET Programming", 15, "Thursday, September 20 2018", "Friday, December 7 2018", 4, 0, "Tuesdays and Thursdays from 2:00 to 4:30 PM");

            Assert.IsTrue(Summarizer.DisplayObjectSummary(testUniversityCourse).Equals($@"Course name: .NET Programming{Environment.NewLine
                                                                                         }Enrolled students: 15{Environment.NewLine
                                                                                         }Waitlisted students: 0{Environment.NewLine
                                                                                         }Start date: Thursday, September 20 2018{Environment.NewLine
                                                                                         }End date: Friday, December 7 2018{Environment.NewLine
                                                                                         }Credit hours: 4{Environment.NewLine
                                                                                         }Weekly schedule: Tuesdays and Thursdays from 2:00 to 4:30 PM"));
        }

        [TestMethod]
        public void DisplayObjectSummary_Event_SummaryIsValid()
        {
            Event testEvent = new Event("UT Weekend", 100000, "November 31st, 2018");

            Assert.IsTrue(Summarizer.DisplayObjectSummary(testEvent).Equals($@"Event name: UT Weekend{Environment.NewLine
                                                                              }Number of attendees: 100000{Environment.NewLine
                                                                              }Date: November 31st, 2018"));
        }

        [TestMethod]
        public void DisplayObjectSummary_ScheduleItemAsUniversityCourse_SummaryIsValid()
        {
            ScheduleItem testUniversityCourse = new UniversityCourse(".NET Programming", 15, "Thursday, September 20 2018", "Friday, December 7 2018", 4, 0, "Tuesdays and Thursdays from 2:00 to 4:30 PM");

            Assert.IsTrue(Summarizer.DisplayObjectSummary(testUniversityCourse).Equals($@"Course name: .NET Programming{Environment.NewLine
                                                                                         }Enrolled students: 15{Environment.NewLine
                                                                                         }Waitlisted students: 0{Environment.NewLine
                                                                                         }Start date: Thursday, September 20 2018{Environment.NewLine
                                                                                         }End date: Friday, December 7 2018{Environment.NewLine
                                                                                         }Credit hours: 4{Environment.NewLine
                                                                                         }Weekly schedule: Tuesdays and Thursdays from 2:00 to 4:30 PM"));
        }

        [TestMethod]
        public void DisplayObjectSummary_ScheduleItemAsEvent_SummaryIsValid()
        {
            ScheduleItem testEvent = new Event("UT Weekend", 100000, "November 31st, 2018");

            Assert.IsTrue(Summarizer.DisplayObjectSummary(testEvent).Equals($@"Event name: UT Weekend{Environment.NewLine
                                                                              }Number of attendees: 100000{Environment.NewLine
                                                                              }Date: November 31st, 2018"));
        }

        [TestMethod]
        public void DisplayObjectSummary_Object_SummaryIsValid()
        {
            Object testObject = new object();
            
            Assert.IsTrue(Summarizer.DisplayObjectSummary(testObject).Equals("System.Object"));
        }

        [TestMethod]
        public void DisplaySummarizableObjectSummary_SummaryIsValid()
        {
            ScheduleItem testUniversityCourse = new UniversityCourse(".NET Programming", 15, "Thursday, September 20 2018", "Friday, December 7 2018", 4, 0, "Tuesdays and Thursdays from 2:00 to 4:30 PM");

            Assert.IsTrue(Summarizer.DisplaySummarizableObjectSummary(testUniversityCourse).Equals($@"Course name: .NET Programming{Environment.NewLine
                                                                                         }Enrolled students: 15{Environment.NewLine
                                                                                         }Waitlisted students: 0{Environment.NewLine
                                                                                         }Start date: Thursday, September 20 2018{Environment.NewLine
                                                                                         }End date: Friday, December 7 2018{Environment.NewLine
                                                                                         }Credit hours: 4{Environment.NewLine
                                                                                         }Weekly schedule: Tuesdays and Thursdays from 2:00 to 4:30 PM"));
        }
    }
}
