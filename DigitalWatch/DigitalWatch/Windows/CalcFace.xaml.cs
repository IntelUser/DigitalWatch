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
using System.Windows.Shapes;

namespace DigitalWatch
{
    /// <summary>
    /// Interaction logic for CalcFace.xaml
    /// </summary>
    public partial class CalcFace : Window
    {
        public CalcFace()
        {
            InitializeComponent();
            OutpuTextBlock.TextTrimming = TextTrimming.CharacterEllipsis;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender;
            //is numer
            int number;
            string symbol;
            if (Int32.TryParse(b.Content.ToString(), out number))
            {
                //do something with number 
                OutpuTextBlock.Text += number.ToString();
            }
            else
            {
                //is operator
                //do something with operator
                symbol = b.Content.ToString();
                OutpuTextBlock.Text += symbol;
            }            

        }

        private void SwitchStatebtn_OnClick(object sender, RoutedEventArgs e)
        {
            Watch.SwitchState();
        }
    }
}
