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

namespace CP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        /// <summary> 
        /// Pomeranje prozora 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Are you sure you want to exit?";
            string title = "Confirm Exit";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText,title,button,icon,MessageBoxResult.Yes);
            if(result == MessageBoxResult.Yes)
            {
                this.Close();
            }

        }

        /// <summary>
        /// Admin Log: 
        /// user : admin 
        /// pw : 20bodova
        /// Guest Log: 
        /// user: guest
        /// pw: bodova20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // implementiraj klasu sa statickim poljem kojem ces pristupati da pamtis ko se ulogovao 
                
                string user_admin = "a";
                string password_admin = "2";
                string user_guest = "u";
                string password_guest = "0";

            if (user_admin.Equals(UserTextBox.Text.ToString()) && PwBox.Password.Equals(password_admin))
            {
                
                AdminWindow adminWin = new AdminWindow();
                this.Hide();
                adminWin.ShowDialog();
                this.Show();
                UserTextBox.Text = "";
                PwBox.Password = "";
            }
            else if (user_guest.Equals(UserTextBox.Text.ToString()) && PwBox.Password.Equals(password_guest))
            {
                
                UserWindow userWin = new UserWindow();
                this.Hide();
                userWin.ShowDialog();
                this.Show();
                UserTextBox.Text = "";
                PwBox.Password = "";
                
            }
            else
            {
                MessageBox.Show("USER NOT FOUND!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                UserTextBox.Text = "";
                PwBox.Password = "";
            }

              


        }


    }
}
