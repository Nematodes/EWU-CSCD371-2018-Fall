using System;

namespace BrianBosAssignmentEight
{
    public class ElapsedTimeModel
    {
        public IDateTime ElapsedTime { get; set; }

        /*
         * The existence of the ElapsedTimeString property is a compromise, as I was unable to properly bind ElapsedTime.
         * Instead, the listbox DisplayMemberPath is set to ElapsedTimeString.
         * 
         * Despite the underlying ElapsedTime type having a working toString() method, the item text is always blank.
         * The blank item is actually in the listbox, and can be selected.
         */
        public string ElapsedTimeString
        {
            get
            {
                return ElapsedTime.ToString();
            }
        }

        public string Description { get; set; }

        public ElapsedTimeModel(IDateTime elapsedTime, string description)
        {
            ElapsedTime = elapsedTime;
            Description = description;
        }
    }
}