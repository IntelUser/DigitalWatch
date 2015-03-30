using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
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

        public void ShowNotification(string subject)
        {

            Task.Factory.StartNew(new Action(() =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var fadeIn = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = new Duration(TimeSpan.FromSeconds(1)),
                        AutoReverse = false
                    };


                    NotifyEllipse.Visibility = Visibility.Visible;
                    MessageBlock.Visibility = Visibility.Visible;
                    MessageBlock.Text = subject;

                    var notifyGeometry = new RectangleGeometry { Rect = new Rect(0, 0, 300, 100) };
                    NotifyEllipse.Clip = notifyGeometry;
                    NotifyEllipse.BeginAnimation(OpacityProperty, fadeIn);
                    MessageBlock.BeginAnimation(OpacityProperty, fadeIn);
                }));


                Thread.Sleep(2000);
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var fadeOut = new DoubleAnimation
                    {
                        From = 1,
                        To = 0,
                        Duration = new Duration(TimeSpan.FromSeconds(1)),
                        AutoReverse = false
                    };
                    NotifyEllipse.BeginAnimation(OpacityProperty, fadeOut);
                    MessageBlock.BeginAnimation(OpacityProperty, fadeOut);
                }));
            }));




        }

        private void Next_window_button_OnClick(object sender, RoutedEventArgs e)
        {
            Watch.SwitchState();
        }

        
    }
}
