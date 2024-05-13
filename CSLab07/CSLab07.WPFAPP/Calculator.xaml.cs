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

namespace Lab7.WpfApp
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public double value1 = 0;
        public string znak = "";
        bool kropka = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 1;
        }

        private void _2_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 2;
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 3;
        }

        private void _4_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 4;
        }

        private void _5_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 5;
        }

        private void _6_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 6;
        }

        private void _7_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 7;
        }

        private void _8_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 8;
        }

        private void _9_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 9;
        }

        private void _00_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += "00";
        }

        private void _0_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text += 0;
        }

        private void _dot_Click(object sender, RoutedEventArgs e)
        {
            if (kropka == false)
            {
                textblc.Text += ',';
                kropka = true;
            }
            
        }

        private void _plus_Click(object sender, RoutedEventArgs e)
        {
            if (value1 != 0)
            {
                zn.Text = "+";
                znak = "+";
            }
            else
            {
                if (double.TryParse("0" + textblc.Text, out var value))
                {
                    value1 = value;
                }
                zn.Text = "+";
                znak = "+";
                textbld.Text = textblc.Text;
                kropka = false;
                textblc.Text = "";
            }
        }

        private void _div_Click(object sender, RoutedEventArgs e)
        {
            if (value1 != 0)
            {
                zn.Text = "÷";
                znak = "/";
            }
            else
            {
                if (double.TryParse("0" + textblc.Text, out var value))
                {
                    value1 = value;
                }
                zn.Text = "\u00F7";  //asci char div
                znak = "/";
                textbld.Text = textblc.Text;
                textblc.Text = "";
                kropka = false;
            }
        }

        private void _mul_Click(object sender, RoutedEventArgs e)
        {
            if (value1 != 0)
            {
                zn.Text = "*";
                znak = "*";
            }
            else
            {
                if (double.TryParse("0"+textblc.Text, out var value))
                {
                    value1 = value;
                }
                zn.Text = "*";
                znak = "*";
                textbld.Text = textblc.Text;
                textblc.Text = "";
                kropka = false;
            }
        }

        private void _minus_Click(object sender, RoutedEventArgs e)
        {
            if (value1 != 0)
            {
                zn.Text = "-";
                znak = "-";
            }
            else
            {
                if (double.TryParse("0"+textblc.Text, out var value))
                {
                    value1 = value;
                }
                znak = "-";
                zn.Text = "-";
                textbld.Text = textblc.Text;
                textblc.Text = "";
                kropka = false;
            }
        }

        private void _C_Click(object sender, RoutedEventArgs e)
        {
            textblc.Text = "";
            textbld.Text = "";
            value1 = 0;
            znak = "";
            zn.Text = "";
            kropka = false;
        }

        private void _equ_Click(object sender, RoutedEventArgs e)
        {
            switch(znak)
            {
                case "+":
                    if (double.TryParse("0"+textblc.Text, out var value))
                    {
                        value1 = value1+value;
                    }
                    textbld.Text = value1.ToString();
                    textblc.Text = "";
                    kropka = false;
                    break;
                case "-":
                    if (double.TryParse("0"+textblc.Text, out var valuesub))
                    {
                        value1 = value1 - valuesub;
                    }
                    textbld.Text = value1.ToString();
                    textblc.Text = "";
                    kropka = false;
                    break;
                case "*":
                    if (double.TryParse("0"+textblc.Text, out var valuemul))
                    {
                        value1 = value1 * valuemul;
                    }
                    textbld.Text = value1.ToString();
                    textblc.Text = "";
                    kropka = false;
                    break;
                case "/":
                    if (double.TryParse("0"+textblc.Text, out var result))
                    {
                        if (result == 0)
                        {
                            _C_Click(sender, e);
                            textblc.Text = "Dzielenie przez 0";
                        }
                        else
                        {
                            value1 = value1 / result;
                            textbld.Text = value1.ToString();
                            textblc.Text = "";
                            kropka = false;
                        }
                    }
                    
                    break;
                default:
                    _C_Click(sender, e);
                   textblc.Text=("Blad");
                    break;
            }
        }
    }
}
