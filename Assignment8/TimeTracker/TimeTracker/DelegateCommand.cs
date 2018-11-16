using System;

namespace BrianBosAssignmentEight
{
    /*
     * Disclaimer:
     * This class code was copied from Intellitect's MVVM getting-started tutorial, which can be found at
     * https://intellitect.com/getting-started-model-view-viewmodel-mvvm-pattern-using-windows-presentation-framework-wpf/
     * 
     * As explained in the source, this is a bare-bones implementation of the ICommand interface.
     */
    public class DelegateCommand : System.Windows.Input.ICommand
    {
        private readonly Action<object> _executeAction;

        public DelegateCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
        }

        public void Execute(object parameter) => _executeAction(parameter);

        // Unused and not properly implemented
        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;
    }
}
