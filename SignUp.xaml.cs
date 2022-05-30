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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            string conString = "Data Source=localhost;Initial Catalog=ExampleDatabase;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            string stmt = "SELECT COUNT(*) FROM dbo.Grouping_Db";
            SqlCommand cmd = new SqlCommand(stmt, con);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            count++;
            con.Close();
            if (UserNameTxt.Text!="")
            {
                if(PassTxt.Password == PassTxt2.Password && PassTxt.Password !="")
                {
                    if(EmailTxt.Text!="")
                    {
                        conString = "Data Source=localhost;Initial Catalog=ExampleDatabase;Integrated Security=True";
                        con = new SqlConnection(conString);
                        con.Open();
                        string Query = "insert into Grouping_Db (ID,Name,Password,Email) values('" + count + "','" + UserNameTxt.Text + "','" + PassTxt.Password + "','" + EmailTxt.Text + "')";
                        cmd = new SqlCommand(Query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Login x = new Login();
                        x.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Email is already Taken");
                    }
                }
                else
                {
                    MessageBox.Show("Passwords are not the same");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Your Name");
            }
        }
    }
}
