using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Base_Converter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            List<Base> baseList = new List<Base>();
            baseList.Add(new Base(2, "Binary"));
            baseList.Add(new Base(10, "Decimal"));
            baseList.Add(new Base(16, "Hexadecimal"));

            foreach (Base curBase in baseList)
            {
                StartBase.DisplayMemberPath = "Name";
                StartBase.Items.Add(curBase);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Exit Application
            CoreApplication.Exit();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Do Calculations

            Base CurBase = (Base) StartBase.SelectedItem;

            if(CurBase.Name == "Binary")
            {
                updateBoxes("Binary", OriginBase.Text);
            }
            else if (CurBase.Name == "Decimal")
            {
                updateBoxes("Decimal", OriginBase.Text);
            }
            else
            {
                updateBoxes("Hexadecimal", OriginBase.Text);
            }
        }

        public void updateBoxes(String baseNAme, string baseValue)
        {
            if(baseNAme == "Binary") //Binary Converter
            {
                string hex = Convert.ToInt32(baseValue, 2).ToString("X");
                string dec = Convert.ToInt32(baseValue, 2).ToString("N0");
                DisplayBox1Header.Text = "Hexadecimal";
                DisplayBox2Header.Text = "Decimal";

                DisplayBox1.Text = hex.ToUpper();
                DisplayBox2.Text = dec;
            }
            else if (baseNAme == "Decimal") //Decimal Converter
            {
                string hex = Convert.ToString(Int64.Parse(baseValue), 16);
                string bin = Convert.ToString(Int64.Parse(baseValue), 2);

                while(bin.Length % 4 != 0)
                {
                    bin = "0" + bin;
                }
                //hex = System.Text.RegularExpressions.Regex.Replace(hex, ".{4}", "$0 ");
                bin = System.Text.RegularExpressions.Regex.Replace(bin, ".{4}", "$0 ");

                DisplayBox1Header.Text = "Hexadecimal";
                DisplayBox2Header.Text = "Binary";

                DisplayBox1.Text = hex.ToUpper();
                DisplayBox2.Text = bin;
            }
            else //Hexadecimal Converter
            {
                string dec = Convert.ToInt32(baseValue, 16).ToString("N0");
                string bin = Convert.ToString(Convert.ToInt64(baseValue, 16), 2);

                while (bin.Length % 4 != 0)
                {
                    bin = "0" + bin;
                }

                bin = System.Text.RegularExpressions.Regex.Replace(bin, ".{4}", "$0 ");
                //hex = System.Text.RegularExpressions.Regex.Replace(hex, ".{4}", "$0 ");

                DisplayBox1Header.Text = "Decimal";
                DisplayBox2Header.Text = "Binary";

                DisplayBox1.Text = dec;
                DisplayBox2.Text = bin;
            }
        }
    }
}
