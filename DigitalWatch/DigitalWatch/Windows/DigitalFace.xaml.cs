using System;
using System.Windows;
using System.Windows.Threading;

namespace DigitalWatch.Windows
{
    /// <summary>
    /// Interaction logic for DigitalFace.xaml
    /// </summary>
    public partial class DigitalFace : IFace
    {
        public DigitalFace()
        {
            InitializeComponent();
        }

        public void UpdateTime(DateTime time)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) (() =>
            {
                time_label.Content = time.ToLongTimeString();
            }));
        }

        public void ShowNotification(string message)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) (() =>
            {
                // update ui
            }));
        }

        private void Next_window_button_OnClick(object sender, RoutedEventArgs e)
        {
            Watch.SwitchState();
        }
    }
}
