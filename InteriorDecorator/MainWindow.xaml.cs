using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace InteriorDecorator
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

        static bool isValidISBN(string isbn)
        {
            int n = isbn.Length;
            if (n != 10)
                return false;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = isbn[i] - '0';

                if (0 > digit || 9 < digit)
                    return false;

                sum += (digit * (10 - i));
            }

            char last = isbn[9];
            if (last != 'X' && (last < '0'
                             || last > '9'))
                return false;

            sum += ((last == 'X') ? 10 :
                              (last - '0'));

            return (sum % 11 == 0);
        }


        public void bCalculateArea_Click(object sender, RoutedEventArgs e)
        {
            int height = int.Parse(tboxHeight.Text);

            
            


            if (height > 6)
            {
                Console.WriteLine("Number is too high");
            }
            if (height < 3)
            {
                Console.WriteLine("Number is too low");
            }
            else
            {
                Console.WriteLine("Valid");
            }

            int length = int.Parse(tboxLength.Text);
            int totalArea = (height * length);

            lbTotalArea.Content = totalArea;
            


            if ((bool)rbLuxury.IsChecked)
            {
                double price = (totalArea * 1.75);
                if ((bool)cbUndercoat.IsChecked)
                {
                    double undercoat = (totalArea * 0.50);
                    double total = (price + undercoat);
                    Console.WriteLine(total);
                    lbTotalCost.Content = total;
                }
                else 
                {
                    Console.WriteLine(price);
                    lbTotalCost.Content = price;

                }
                
            }
            if ((bool)rbStandard.IsChecked)
            {
                double price = (totalArea * 1);
                if ((bool)cbUndercoat.IsChecked)
                {
                    double undercoat = (totalArea * 0.50);
                    double total = (price + undercoat);
                    lbTotalCost.Content = total;
                    Console.WriteLine(total);
                }
                else
                {
                    Console.WriteLine(price);
                    lbTotalCost.Content = price;

                }

            }
            if ((bool)rbEconomy.IsChecked)
            {
                double price = (totalArea * 0.45);
                if ((bool)cbUndercoat.IsChecked)
                {
                    double undercoat = (totalArea * 0.50);
                    double total = (price + undercoat);
                    lbTotalCost.Content = total;
                    Console.WriteLine(total);
                }
                else
                {
                    Console.WriteLine(price);
                    lbTotalCost.Content = price;

                }

                
                

            }


            //Console.WriteLine(rbLuxury.IsChecked);
            //Console.WriteLine(rbStandard.IsChecked);
            //Console.WriteLine(rbEconomy.IsChecked);
            //Console.WriteLine(cbUndercoat.IsChecked);

 


        }

        public void bSubmit_Click(object sender, RoutedEventArgs e)

        {
            string name = (tboxName.Text);

            string result = string.Empty;
            if (string.IsNullOrEmpty(name))
            {
                result = "Name is mandatory";

            }
            


            var choice = "Not Selected ";
            if ((bool)rbLuxury.IsChecked)
            {
                choice = "Luxury";
            }
            if ((bool)rbStandard.IsChecked)
            {
                choice = "Standard";
            }
            if ((bool)rbEconomy.IsChecked)
            {
                choice = "Economy";
            }
            var undercoatChoice = "N/A";

            if ((bool)cbUndercoat.IsChecked)
            {
                undercoatChoice = "Yes";
            }
            else
            {
                undercoatChoice = "No";
            }






            string email = (tboxEmail.Text);


            var isbn = tboxISBN.Text;

            if (isValidISBN(isbn))
                Console.WriteLine("Valid ISBN");
            else
                Console.WriteLine("Invalid ISBN");


            int pagenumber = int.Parse(tboxPageNumber.Text);


            lbSummery.Content = "Name : " + name + "\nEmail : " + email + "\nISBN : " + isbn + "\nPage Number : " + pagenumber + "\n-------------------------------" + "\nRoom Area : " + lbTotalArea.Content + " M²" + "\nPaint : " + choice + "\nUndercoat : " + undercoatChoice + "\nTotal : £" + lbTotalCost.Content + "\n-------------------------------";
        }
    }
}