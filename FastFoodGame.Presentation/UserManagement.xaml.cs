using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FastFoodGame.BusinessLayer;
using FastFoodGame.Framework;

namespace FastFoodGame.Presentation
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Window
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void cboUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserController.AddUser(new User { Name = cboUsers.Text });
                MessageBox.Show("Added user!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding new user: " + ex.Message);
            }
        }

        private void UserManagement_Loaded(object sender, RoutedEventArgs e)
        {
            cboUsers.Focus();
        }
    }
}
