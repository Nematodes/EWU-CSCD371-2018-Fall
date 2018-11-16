using System;
using System.Collections.ObjectModel;

namespace BrianBosAssignmentEight
{
    /*
     * I considered splitting TimeTrackerViewModel into smaller classes, but then decided against it.
     * 
     * Is separating out functionality for modularity/single responsibility even a good idea? Probably not in this case.
     * 
     * Moving individual view element binding point groups (such as a button's text and command) into their own classes would
     * not particularly reduce complexity or testability in a small application like this.
     * 
     * There are many possible view elements, each with their own set of customizations.
     * Following the logic of modularization, there would have to be a fully-fledged framework of abstracted templates ready to
     * handle any possible configuration of bindings. This sounds like an interesting idea for a framework, not a single small project.
     * 
     * Methods are public for unit testing purposes.
     */
    public class TimeTrackerViewModel : TimeTrackerViewModelBase
    {
        public IDateTime CurrentTime { get; set; } // Public for unit testing purposes

        private string _CurrentTimeText;
        public string CurrentTimeText
        {
            get
            {
                return _CurrentTimeText;
            }
            set
            {
                SetProperty(ref _CurrentTimeText, value);
            }
        }

        public IDateTime StartTime { get; set; }

        private string _StartTimeText;
        public string StartTimeText
        {
            get
            {
                return _StartTimeText;
            }
            set
            {
                SetProperty(ref _StartTimeText, value);
            }
        }

        public IDateTime EndTime { get; set; }

        private string _EndTimeText;
        public string EndTimeText
        {
            get
            {
                return _EndTimeText;
            }
            set
            {
                SetProperty(ref _EndTimeText, value);
            }
        }

        public ObservableCollection<ElapsedTimeModel> ElapsedTimeList { get; set; }

        private int _ElapsedTimeListBoxSelectedIndex;
        public int ElapsedTimeListBoxSelectedIndex
        {
            get
            {
                return _ElapsedTimeListBoxSelectedIndex;
            }
            set
            {
                _ElapsedTimeListBoxSelectedIndex = value;

                OnListBoxItemSelect();
            }
        }

        private string _SelectedTimeDescriptionText;
        public string SelectedTimeDescriptionText
        {
            get
            {
                return _SelectedTimeDescriptionText;
            }
            set
            {
                SetProperty(ref _SelectedTimeDescriptionText, value);

                if (ElapsedTimeListBoxSelectedIndex >= 0 && ElapsedTimeList.Count >= 1)
                {
                    ElapsedTimeList[ElapsedTimeListBoxSelectedIndex].Description = SelectedTimeDescriptionText;
                }
            }
        }

        private bool _IsSelectedTimeDescriptionTextBoxEnabled;
        public bool IsSelectedTimeDescriptionTextBoxEnabled
        {
            get
            {
                return _IsSelectedTimeDescriptionTextBoxEnabled;
            }
            set
            {
                SetProperty(ref _IsSelectedTimeDescriptionTextBoxEnabled, value);
            }
        }

        private System.Windows.Threading.DispatcherTimer TimeUpdateTimer;

        private readonly DelegateCommand _DeleteEntryButtonClickCommand;
        public System.Windows.Input.ICommand DeleteEntryButtonClickCommand => _DeleteEntryButtonClickCommand;

        private readonly DelegateCommand _TimerButtonClickCommand;
        public System.Windows.Input.ICommand TimerButtonClickCommand => _TimerButtonClickCommand;

        private string _TimerButtonText;
        public string TimerButtonText
        {
            get
            {
                return _TimerButtonText;
            }
            set
            {
                SetProperty(ref _TimerButtonText, value);
            }
        }

        public TimeTrackerViewModel(IDateTime currentTime)
        {
            ElapsedTimeList = new ObservableCollection<ElapsedTimeModel>();

            _DeleteEntryButtonClickCommand = new DelegateCommand(OnDeleteEntryButtonClick);
            _TimerButtonClickCommand = new DelegateCommand(OnTimerButtonClick);

            SelectedTimeDescriptionText = "No time entries are currently selected.";
            IsSelectedTimeDescriptionTextBoxEnabled = false;

            CurrentTime = currentTime;
            CurrentTime.Hours = DateTime.Now.Hour;
            CurrentTime.Minutes = DateTime.Now.Minute;
            CurrentTime.Seconds = DateTime.Now.Second;

            TimeUpdateTimer = new System.Windows.Threading.DispatcherTimer();
            TimeUpdateTimer.Interval = new TimeSpan(0, 0, 1);
            TimeUpdateTimer.Tick += CurrentTimeUpdate;
            TimeUpdateTimer.Start();

            CurrentTimeText = $"Current time: {CurrentTime.ToString()}";
            StartTimeText = "Start time: --:--:--";
            EndTimeText = "End time: --:--:--";

            TimerButtonText = "Start";
        }

        public void OnDeleteEntryButtonClick(object commandParameter)
        {
            if (ElapsedTimeListBoxSelectedIndex != -1)
            {
                ElapsedTimeList.RemoveAt(ElapsedTimeListBoxSelectedIndex);
            }
        }

        public void OnListBoxItemSelect()
        {
            if (ElapsedTimeListBoxSelectedIndex >= 0)
            {
                IsSelectedTimeDescriptionTextBoxEnabled = true;
                SelectedTimeDescriptionText = ElapsedTimeList[ElapsedTimeListBoxSelectedIndex].Description;
            }
            else
            {
                IsSelectedTimeDescriptionTextBoxEnabled = false;
                SelectedTimeDescriptionText = "No time entries are currently selected.";
            }
        }

        public void OnTimerButtonClick(object commandParameter)
        {
            // State is the enemy of testing, but I cannot think of a reasonable alternative
            if (TimerButtonText == "Start")
            {
                StartTime = (IDateTime) CurrentTime.Clone();
                StartTimeText = $"Start time: {StartTime.ToString()}";
                EndTimeText = "End time: --:--:--";
                TimerButtonText = "Stop";
            }
            else
            {
                EndTime = (IDateTime) CurrentTime.Clone();
                EndTimeText = $"End time: {EndTime.ToString()}";
                TimerButtonText = "Start";

                ElapsedTimeList.Add(new ElapsedTimeModel(EndTime.Difference(StartTime), "Add your description here"));
            }
        }

        public void CurrentTimeUpdate(object sender, EventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;

            CurrentTime.Hours = currentDateTime.Hour;
            CurrentTime.Minutes = currentDateTime.Minute;
            CurrentTime.Seconds = currentDateTime.Second;

            CurrentTimeText = $"Current time: {CurrentTime.ToString()}";
        }
    }
}