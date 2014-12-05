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
using Tester_losowości.Model;

namespace Tester_losowości
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

        private string wej_string;

        private void Test_run(object sender, RoutedEventArgs e)
        {
            wej_string = System.IO.File.ReadAllText(wej.Text);
            Test test=new Test(wej_string);

            DlugiejSeriiTextBox.Text= test.TestDlugiejSerii().ToString();
            ProgresBar.Value = 25;
            ParBitowTextBox.Text=test.TestParBitow().ToString();
            ProgresBar.Value = 50;
            PojedynczychBitowTextBox.Text=test.TestPojedynczychBitow().ToString();
            ProgresBar.Value = 75;
            AutokorelacjiTextBox.Text=test.Test_Autokorelacji().ToString();
            ProgresBar.Value = 100;
        }
    }
}
