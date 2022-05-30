using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for AssignStudentsToGroups.xaml
    /// </summary>
    public partial class AssignStudentsToGroups : Window
    {
        public StackPanel sp = new StackPanel();
        public MainWindow Y;
        public AssignStudentsToGroups(string NumGroup, string NumScreen, MainWindow X)
        {
            InitializeComponent();
            Y = X;
            InitializeComponent();
            if (NumGroup == null)
            {
                NumGroup = "5";
            }
            for (int i = 1; i < int.Parse(NumGroup) + 1; i++)
            {

                comboBox.Items.Add(i);
            }
            for (int i = 1; i < int.Parse(NumScreen) + 1; ++i)
            {
                string conString = "Data Source=localhost;Initial Catalog=ExampleDatabase;Integrated Security=True";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string selectSql = "select GroupID,Email,Password,Type,Screens,name,ID from Grouping_Db Where ID=@ID";
                SqlCommand cmd = new SqlCommand(selectSql, con);
                cmd.Parameters.AddWithValue("ID", i);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                string tent = "";
                string GroupNum = "";
                if (reader.Read())
                {
                    tent = reader["Name"].ToString();
                    GroupNum = reader["GroupID"].ToString();
                }
                Button button = new Button()
                {
                    Content = string.Format(tent, i),
                    Tag = i,
                    Background = Brushes.White

                };
                if (Y.CtGroups > 0)
                {
                    var values = typeof(Brushes).GetProperties().
                               Select(p => new { Name = p.Name, Brush = p.GetValue(null) as Brush }).
                               ToArray();
                    int k = 0;
                    if(GroupNum !=k.ToString())
                    {
                        button.Background = values[i].Brush;
                    }
                
                }

                button.Click += new RoutedEventHandler(button_Click);
                this.grid.Children.Add(button);
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex > -1)
            {
                Button conBut = (Button)sender;
                string con ="" ;


                for (int i = 1; i < int.Parse(Y.NumOfGroups) + 1; i++)
                {
                    string t = comboBox.SelectedItem.ToString();
                    string conString = "Data Source=localhost;Initial Catalog=ExampleDatabase;Integrated Security=True";
                    SqlConnection con2 = new SqlConnection(conString);
                    con2.Open();
                    string selectSql = "select GroupID,Email,Password,Type,Screens,name,ID from Grouping_Db Where ID=@ID";
                    SqlCommand cmd = new SqlCommand(selectSql, con2);
                    cmd.Parameters.AddWithValue("ID", i);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        con = reader["ID"].ToString();
                    }
                    
                    if (con == t)
                    {
                        var values = typeof(Brushes).GetProperties().
                               Select(p => new { Name = p.Name, Brush = p.GetValue(null) as Brush }).
                               ToArray();
                        if (conBut.Background != Brushes.White)
                        {
                            SqlConnection con1 = new SqlConnection(conString);
                            con1.Open();
                            int z = 0;
                            string Query = "Update  Grouping_Db set GroupID='" + z + "'Where Name='" + conBut.Content + "'";
                            cmd = new SqlCommand(Query, con1);
                            cmd.ExecuteNonQuery();
                            con1.Close();
                            conBut.Background = Brushes.White;
                        }
                        else
                        {
                            conBut.Background = values[i - 1].Brush;

                            SqlConnection con1 = new SqlConnection(conString);
                            con1.Open();
                            string Query = "Update  Grouping_Db set GroupID='"+int.Parse(t)+"'Where Name='"+ conBut.Content+ "'"; 
                            cmd = new SqlCommand(Query, con1);
                            cmd.ExecuteNonQuery();
                            con1.Close();
                        }

                    }

                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow X = new MainWindow();
            X = Y;
            X.Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
