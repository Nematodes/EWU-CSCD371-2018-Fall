using System;

namespace BrianBosAssignmentSix
{
    public abstract class ScheduleItem : IEvent
    {
        //public enum Day

        public string Name { get; set; }

        private int _NumberOfAttendees;
        public int NumberOfAttendees
        {
            get
            {
                return _NumberOfAttendees;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of attendees cannot be less than 0.");
                }
                else
                {
                    _NumberOfAttendees = value;
                }
            }
        }


        /*
         * NumberOfInstantiatedScheduleItems accumulates the number of ScheduleItem objects instantiated,
         * not the current amount of ScheduleItem objects in memory.
         * 
         * Originally, a destructor was used to decrement NumberOfInstantiatedScheduleItems,
         * but it didn't prove very useful - the garbage collector unpredictably cleaned up
         * out-of-scope objects.
         */
        private static int _NumberOfInstantiatedScheduleItems = 0;
        public static int NumberOfInstantiatedScheduleItems
        {
            get
            {
                return _NumberOfInstantiatedScheduleItems;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of instantiated schedule items cannot be less than 0.");
                }
                else
                {
                    _NumberOfInstantiatedScheduleItems = value;
                }
            }
        }

        public ScheduleItem(string name, int numberOfAttendees)
        {
            Name = name;
            NumberOfAttendees = numberOfAttendees;

            NumberOfInstantiatedScheduleItems++;
        }

        public abstract string GetSummaryInformation();
    }
}