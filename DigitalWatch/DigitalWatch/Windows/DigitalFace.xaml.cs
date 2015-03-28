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
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using DigitalWatch;

namespace clock
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DigitalFace : Window
    {
        readonly System.Timers.Timer _timer = new System.Timers.Timer(1000);

        public DigitalFace()
        {
            InitializeComponent();

            time_label.Content =  Time.TimeManager.GetTime().ToLongTimeString();

            _timer.Elapsed += timer_Elapsed;
            _timer.Enabled = true;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                 time_label.Content = Time.TimeManager.GetTime().ToLongTimeString();
            }));
        }


        private void Next_window_button_OnClick(object sender, RoutedEventArgs e)
        {
            Watch.SwitchState();
        }
    }
}
