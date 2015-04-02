using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DigitalWatch.Windows
{
    /// <summary>
    ///     Interaction logic for CalcFace.xaml
    /// Uses Reverse Polish Notation!
    /// </summary>
    public partial class CalcFace : IFace
    {
        private string tokenString = String.Empty;
        private bool _isResult;
        public CalcFace()
        {
            InitializeComponent();
            OutpuTextBlock.TextTrimming = TextTrimming.CharacterEllipsis;
        }

        public void UpdateTime(DateTime time)
        {
            Console.WriteLine(@"Calculator Time is:{0}", time.ToLongTimeString());
        }

        public void ShowNotification(string message, string from)
        {
            Task.Factory.StartNew(() =>
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
                    MessageBlock.Text = String.Format("From: {0}, Message: {1}", from, message);

                    var notifyGeometry = new RectangleGeometry {Rect = new Rect(0, 0, 300, 100)};
                    NotifyEllipse.Clip = notifyGeometry;
                    NotifyEllipse.BeginAnimation(OpacityProperty, fadeIn);
                    MessageBlock.BeginAnimation(OpacityProperty, fadeIn);
                }));


                Thread.Sleep(3000);
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
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isResult)
            {
                OutpuTextBlock.Text = "";
                _isResult = false;
            }
            var b = (Button) sender;
            //is number
            int number;
            if (Int32.TryParse(b.Content.ToString(), out number))
            {
                //do something with number 
                OutpuTextBlock.Text += String.Format("{0} ", number);
                tokenString += String.Format("{0} ", number);
            }
            else if (b.Content.ToString().Equals("="))
            {
                //is enter
                var tokenList = new List<string>(tokenString.Split(' '));

                IExpression expression = new TokenReader().ReadToken(tokenList);

                if (expression != null)
                {
                    OutpuTextBlock.Text = expression.Interpret().ToString();
                    _isResult = true;

                    tokenString = "";
                    tokenList.Clear();
                }
                else
                {
                    tokenList.Clear();
                   Watch.ShowEmailNotification("Invalid command","calculator");
                    OutpuTextBlock.Text = "";
                }
                
            }
            else
            {
                //is operator
                //do something with operator
                string symbol = b.Content.ToString();
                OutpuTextBlock.Text += String.Format("{0} ", symbol);
                tokenString += String.Format("{0} ", symbol);
            }
        }


        public class AddExpression : IExpression
        {
            private readonly IExpression _leftExpression;
            private readonly IExpression _rightExpression;

            public AddExpression(IExpression left, IExpression right)
            {
                _leftExpression = left;
                _rightExpression = right;
            }

            int IExpression.Interpret()
            {
                return _leftExpression.Interpret() + _rightExpression.Interpret();
            }
        }

        public class MultiplyExpression : IExpression
        {
            private readonly IExpression _leftExpression;
            private readonly IExpression _rightExpression;

            public MultiplyExpression(IExpression left, IExpression right)
            {
                _leftExpression = left;
                _rightExpression = right;
            }

            int IExpression.Interpret()
            {
                return _leftExpression.Interpret() * _rightExpression.Interpret();
            }
        }

        public class DivideExpression : IExpression
        {
            private readonly IExpression leftExpression;
            private readonly IExpression rightExpression;

            public DivideExpression(IExpression left, IExpression right)
            {
                leftExpression = left;
                rightExpression = right;
            }

            int IExpression.Interpret()
            {
                return leftExpression.Interpret() / rightExpression.Interpret();
            }
        }

        public interface IExpression
        {
            int Interpret();
        }

//terminal expression
        public class NumberExpression : IExpression
        {
            private readonly int number;

            public NumberExpression(int i)
            {
                number = i;
            }

            int IExpression.Interpret()
            {
                return number;
            }
        }

//nonterminal expression, contains left and right expressions below it

//nonterminal expression, contains left and right expressions below it
        public class SubtractExpression : IExpression
        {
            private readonly IExpression leftExpression;
            private readonly IExpression rightExpression;

            public SubtractExpression(IExpression left, IExpression right)
            {
                leftExpression = left;
                rightExpression = right;
            }

            int IExpression.Interpret()
            {
                return leftExpression.Interpret() - rightExpression.Interpret();
            }
        }

        public class TokenReader
        {
            public IExpression ReadToken(List<string> tokenList)
            {
                return ReadNextToken(tokenList);
            }

            private IExpression ReadNextToken(List<string> tokenList)
            {
                try
                {
                    int i;
                    if (int.TryParse(tokenList.First(), out i)) //if the token is integer (terminal)
                    {
                        tokenList.RemoveAt(0); //process terminal expression
                        return new NumberExpression(i);
                    }
                    return ReadNonTerminal(tokenList); //process nonTerminal expression
                }
                catch (InvalidOperationException ioe)
                {
                    return null;
                }
               
            }

            private IExpression ReadNonTerminal(List<string> tokenList)
            {
                var token = tokenList.First();
                tokenList.RemoveAt(0); //read the symbol
                IExpression left = ReadNextToken(tokenList); //read left expression
                IExpression right = ReadNextToken(tokenList); //read right expression
                if (left != null && right != null)
                {
                    switch (token)
                    {
                        case "+":
                            return new AddExpression(left, right);
                            break;
                        case "-":
                            return new SubtractExpression(left, right);
                            break;
                        case "/":
                            return new DivideExpression(left, right);
                            break;
                        case "*":
                            return new MultiplyExpression(left, right);
                            break;
                        default:
                            return null;
                            break;
                    }
                }
                else
                {
                    return null;    // invalid expression
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && !e.IsRepeat)
            {
                Watch.SwitchState();
            }
        }
    }
}