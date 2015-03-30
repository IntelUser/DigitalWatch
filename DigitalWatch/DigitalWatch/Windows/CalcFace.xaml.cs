using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DigitalWatch.Windows
{
    /// <summary>
    /// Interaction logic for CalcFace.xaml
    /// </summary>
    public partial class CalcFace : IFace
    {
        public CalcFace()
        {
            InitializeComponent();
            OutpuTextBlock.TextTrimming = TextTrimming.CharacterEllipsis;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button) sender;
            //is number
            int number;
            if (Int32.TryParse(b.Content.ToString(), out number))
            {
                //do something with number 
                OutpuTextBlock.Text += number.ToString();
            }
            else
            {
                //is operator
                //do something with operator
                var symbol = b.Content.ToString();
                OutpuTextBlock.Text += symbol;
            }
        }

        private void SwitchStatebtn_OnClick(object sender, RoutedEventArgs e)
        {
            Watch.SwitchState();
        }

        public void UpdateTime(DateTime time)
        {
            Console.WriteLine(@"Calculator Time is:{0}", time.ToLongTimeString());
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
    }
}
