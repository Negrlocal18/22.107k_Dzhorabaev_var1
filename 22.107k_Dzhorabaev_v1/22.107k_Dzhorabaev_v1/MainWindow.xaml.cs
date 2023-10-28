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

namespace _22._107k_Dzhorabaev_v1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;

                if (input.Length != 12)
                {
                    throw new ArgumentException("Number must have exactly 12 digits.");
                }

                long number = long.Parse(input);

                int firstThreeDigits = GetFirstThreeDigits(number);
                int lastNineDigitsSum = GetLastNineDigitsSum(number);

                if (firstThreeDigits * 9 == lastNineDigitsSum)
                {
                    OutputTextBox.Text = "Произведение первых 3 десятичных цифр равно сумме 9 последних десятичных цифр.";
                }
                else
                {
                    OutputTextBox.Text = "Произведение первых 3 десятичных цифр не равно сумме 9 последних десятичных цифр.";
                }
            }
            catch (Exception )
            {
                OutputTextBox.Text=("введите двенадцатизначное число");
            }
        }

        private int GetFirstThreeDigits(long number)
        {
            string numberString = number.ToString();
            return int.Parse(numberString.Substring(0, 3));
        }

        private int GetLastNineDigitsSum(long number)
        {
            string numberString = number.ToString();
            string lastNineDigitsString = numberString.Substring(numberString.Length - 9);
            int sum = 0;
            foreach (char digitChar in lastNineDigitsString)
            {
                sum += int.Parse(digitChar.ToString());
            }
            return sum;
        }
    }
}