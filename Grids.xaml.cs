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
    /// Interaction logic for Grids.xaml
    /// </summary>
    public partial class Grids : Window
    {
        DataClassesDataContext dc = new DataClassesDataContext(Properties.Settings.Default.ExampleDatabaseConnectionString);
        public Grids()
        {
            InitializeComponent();
            if(dc.DatabaseExists())
            {
                dataGrid.ItemsSource = dc.Grouping_Dbs;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
