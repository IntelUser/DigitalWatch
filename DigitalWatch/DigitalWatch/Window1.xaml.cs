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
using MohammadDayyanCalendar;

namespace clock
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);

        public Window1()
        {
            InitializeComponent();

            MDCalendar mdCalendar = new MDCalendar();
            DateTime date = DateTime.Now;
            TimeZone time = TimeZone.CurrentTimeZone;
            TimeSpan difference = time.GetUtcOffset(date);
            uint currentTime = mdCalendar.Time() + (uint)difference.TotalSeconds;
           // persianCalendar.Content = mdCalendar.Date("Y/m/D  W", currentTime, true);
            christianityCalendar.Content = mdCalendar.Date("P Z/e/d", currentTime, false);

            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //http://thispointer.spaces.live.com/blog/cns!74930F9313F0A720!252.entry?_c11_blogpart_blogpart=blogview&_c=blogpart#permalink
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
            //da.RepeatBehavior=new RepeatBehavior(3);


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
