using System.Collections.Generic;
using System.ComponentModel;

namespace BrianBosAssignmentEight
{
    /*
     * Disclaimer:
     * This class code was almost entirely copied (barring minor nonfunctional changes and stylistic modifications) from Intellitect's MVVM getting-started tutorial,
     * which can be found at https://intellitect.com/getting-started-model-view-viewmodel-mvvm-pattern-using-windows-presentation-framework-wpf/
     * 
     * I at least understand everything it does.
     */
    public abstract class TimeTrackerViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

                return true;
            }

            return false;
        }
    }
}
