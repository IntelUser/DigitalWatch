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
    public partial class Window1 : Window
    {
        readonly System.Timers.Timer _timer = new System.Timers.Timer(1000);

        public Window1()
        {
            //new CalcFace().Show(); this we want to happen in a different state
            InitializeComponent();

            DateLabel.Content = String.Format("{0:dddd, MMMM d, yyyy}", Time.TimeManager.GetTime());

            _timer.Elapsed += timer_Elapsed;
            _timer.Enabled = true;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                secondHand.Angle = DateTime.Now.Second * 6;
                minuteHand.Angle = DateTime.Now.Minute * 6;
                hourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
            }));
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ShowNotification(string email = "New Email!")
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 1;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            da.AutoReverse = false;

            NotifyEllipse.Visibility = Visibility.Visible;
            MessageBlock.Visibility = Visibility.Visible;
            MessageBlock.Text = email;

            RectangleGeometry notifyGeometry = new RectangleGeometry();
            notifyGeometry.Rect = new Rect(0, 0, 300, 100);
            NotifyEllipse.Clip = notifyGeometry;
            NotifyEllipse.BeginAnimation(OpacityProperty, da);
            MessageBlock.BeginAnimation(OpacityProperty, da);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowNotification();
        }
    }
}
