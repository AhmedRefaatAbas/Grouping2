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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string conString = "Data Source=localhost;Initial Catalog=ExampleDatabase;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string selectSql = "select GroupID,Email,Password,Type,Screens,name,ID from Grouping_Db Where ID=@ID";
            SqlCommand cmd = new SqlCommand(selectSql, con);
            string stmt = "SELECT COUNT(*) FROM dbo.Grouping_Db";
            cmd = new SqlCommand(stmt, con);
            string Name;
            string pass;
            int v = (int)cmd.ExecuteScalar();
            con.Close();
            for (int i =0; i<v;i++)
            {
                con.Open();
                cmd = new SqlCommand(selectSql, con);
                cmd.Parameters.AddWithValue("ID", i);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                
                if (reader.Read())
                {
                    Name = reader["Name"].ToString();
                    pass = reader["Password"].ToString();
                    if (Name == UserNameTxt.Text)
                    {
                        if(pass == PassTxt.Password)
                        {
                            MainWindow x = new MainWindow();
                            x.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Password is Wrong");
                        }
                    }

                }
                con.Close();
            }
            

        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            SignUp X = new SignUp();
            X.Show();
            this.Close();
        }
    }
}
