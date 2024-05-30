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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isCalculate = false;
        private double res = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if (!isCalculate)
                {
                    if (textBox1.Text == "/" || textBox1.Text == "*" || textBox1.Text == "-" || textBox1.Text == "+")
                    {
                        textBox1.Text = ((TextBlock)(sender as Button).Content).Text;
                    }
                    else
                    {
                        textBox1.Text += ((TextBlock)(sender as Button).Content).Text;
                    }
                }
                else
                {
                    textBox2.Text = res.ToString();
                    if (textBox1.Text == "/" || textBox1.Text == "*" || textBox1.Text == "-" || textBox1.Text == "+")
                    {
                        textBox1.Text = ((TextBlock)(sender as Button).Content).Text;
                    }
                    else
                    {
                        textBox1.Text += ((TextBlock)(sender as Button).Content).Text;
                    }
                    isCalculate = false;
                }
            }
        }

        private void ButtonNonNumber_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if (!isCalculate)
                {
                    textBox2.Text = "";
                }
                textBox2.Text += textBox1.Text;
                textBox2.Text += ((TextBlock)(sender as Button).Content).Text;
                textBox1.Text = ((TextBlock)(sender as Button).Content).Text;
            }
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(textBox1.Text) > 0)
            {
                textBox1.Text = "-" + textBox1.Text;
            }
            else
            {
                textBox1.Text = (Math.Abs(Convert.ToDouble(textBox1.Text))).ToString();
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            textBox2.Text += textBox1.Text;

            string[] a = textBox2.Text.Split('/', '*', '-', '+');
            string[] b = textBox2.Text.Split('1', '2', '3', '4', '5', '6', '7', '8', '9', '0');
            List<string> bList = new List<string>(b.ToList());
            for (int i = 0; i < bList.Count; i++)
            {
                if (bList[i] == "")
                {
                    bList.Remove("");
                    i--;
                }

            }
            if (!String.IsNullOrEmpty(a[0]))
            {
                res = Convert.ToDouble(a[0]);
            }
            else
            {
                return;
            }
            for (int i = 0; i < a.Length - 1; i++)
            {
                double secondRes = Convert.ToDouble(a[i + 1]);
                switch (bList[i])
                {
                    case "/": res = res / secondRes; break;
                    case "*": res = res * secondRes; break;
                    case "-": res = res - secondRes; break;
                    case "+": res = res + secondRes; break;
                }
            }
            textBox1.Text = res.ToString();
            isCalculate = true;
        }

        private void CEB_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void CB_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            string a = textBox1.Text;
            textBox1.Text = "";
            if (!String.IsNullOrEmpty(a))
            {
                for (int i = 0; i < a.Length - 1; i++)
                {
                    textBox1.Text += a[i];
                }
            }
        }
    }
}
