using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleTimeTracker
{
    public partial class TimeTracker : Window
    {
        private DateTime _startTime;
        private TimeSpan _workingTime = new TimeSpan();

        public TimeTracker()
        {
            InitializeComponent();
        }

        private void OnStartWork( object sender, RoutedEventArgs e )
        {
            _startTime = DateTime.Now;
            startwork.IsEnabled = false;
            startbreak.IsEnabled = true;
            finishwork.IsEnabled = true;
        }

        private void OnFinishWork( object sender, RoutedEventArgs e )
        {
            _workingTime += DateTime.Now - _startTime;
            UpdateWorkText();
        }

        private void OnStartBreak( object sender, RoutedEventArgs e )
        {
            _workingTime += DateTime.Now - _startTime;
            endbreak.IsEnabled = true;
            startbreak.IsEnabled = false;
            UpdateWorkText();
        }

        private void OnEndBreak( object sender, RoutedEventArgs e )
        {
            endbreak.IsEnabled = false;
            startbreak.IsEnabled = true;
            _startTime = DateTime.Now;
       }

        private void UpdateWorkText()
        {
            worktext.Text = "WorkTime: " + _workingTime.ToString();
        }
    }
}
