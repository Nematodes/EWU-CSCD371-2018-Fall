using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BrianBosAssignmentEight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TimeTrackerView : Window
    {
        private TimeTrackerViewModel ViewModel { get; }

        public TimeTrackerView()
        {
            ViewModel = new TimeTrackerViewModel(new TimeTrackerDateTime(1, 1, 1));

            DataContext = ViewModel;

            InitializeComponent();
        }

        private void MainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newHeight = (MainGrid.RowDefinitions.First().ActualHeight / 4) - 30;

            if (newHeight >= 0)
            {
                CurrentTime.Padding = new Thickness(0, newHeight, 0, 0);
            }
        }
    }
}