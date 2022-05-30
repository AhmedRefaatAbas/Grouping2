using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for AssignScreensToGroups.xaml
    /// </summary>
    public partial class AssignScreensToGroups : Window
    {
        public StackPanel sp = new StackPanel();
        public MainWindow Y;
        
        public object Children { get; }
        
        public AssignScreensToGroups(string NumGroup,string NumScreen,MainWindow X)
        {
            
            Y = X;
            InitializeComponent();
            
            if (NumGroup == null)
            {
                NumGroup="5";
            }
            for (int i = 1;i < int.Parse(NumGroup) +1;i++)
            {
                
                comboBox.Items.Add(i);
            }
            for (int i = 1; i < int.Parse(NumScreen) + 1; ++i)
            {
                Button button = new Button()
                {
                    Content = string.Format(i.ToString(), i),
                    Tag = i,
                    Background = Brushes.White
                    
                };
                if(Y.CtScreen >= 1)
                {
                    for (int k = 1; k < int.Parse(Y.NumOfGroups) + 1; k++)
                    {
                        for (int j = 0; j < Y.groups[k - 1].ScreenId.Count; j++)
                        {
                            if (Y.groups[k - 1].ScreenId[j] == i)
                            {
                                var values = typeof(Brushes).GetProperties().
                               Select(p => new { Name = p.Name, Brush = p.GetValue(null) as Brush }).
                               ToArray();

                                button.Background = values[k-1].Brush;
                                
                            }
                        }
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
                string con = conBut.Content.ToString();


                for (int i = 1; i < int.Parse(Y.NumOfGroups) + 1; i++)
                {
                    string t = comboBox.SelectedItem.ToString();
                    if (Y.groups[i - 1].Group_Id == int.Parse(t))
                    {
                       
                        if (conBut.Background != Brushes.White)
                        {
                            for (int k = 1; k < int.Parse(Y.NumOfGroups) + 1; k++)

                                for (int j=0;j<Y.groups[k-1].ScreenId.Count;j++)
                                {
                                
                                     if(Y.groups[k - 1].Group_Id.ToString()==t&& Y.groups[k - 1].ScreenId[j] ==int.Parse(con))
                                     {
                                        Y.groups[k-1].ScreenId.RemoveAt(j);
                                        var values = typeof(Brushes).GetProperties().
                                           Select(p => new { Name = p.Name, Brush = p.GetValue(null) as Brush }).
                                           ToArray();

                                       // conBut.Background = values[k].Brush;
                                        conBut.Background = Brushes.White;
                                        break;


                                     }
                                
                                }
                            
                        }
                        else
                        {
                            var values = typeof(Brushes).GetProperties().
                               Select(p => new { Name = p.Name, Brush = p.GetValue(null) as Brush }).
                               ToArray();

                            conBut.Background = values[int.Parse(t)].Brush;
                            Y.groups[i - 1].ScreenId.Add(int.Parse(con));
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
        
    }
}
