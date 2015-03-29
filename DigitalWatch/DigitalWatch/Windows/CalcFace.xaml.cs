using System;
using System.Windows;
using System.Windows.Controls;

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

        public void ShowNotification(string message)
        {
           Console.WriteLine(@"Notification: {0}", message);
        }
    }
}
