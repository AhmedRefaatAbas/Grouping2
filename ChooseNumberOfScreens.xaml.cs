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

namespace Grouping
{
    /// <summary>
    /// Interaction logic for ChooseNumberOfScreens.xaml
    /// </summary>
    public partial class ChooseNumberOfScreens : Window
    {
        public MainWindow Y;
        public string Num;
        public ChooseNumberOfScreens(MainWindow X,string Num1)
        {
            InitializeComponent();
            Y = X;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Y.NumOfGroups = textBox.Text;
            MainWindow main = Y;
            
            this.Close();
        }
    }
}
