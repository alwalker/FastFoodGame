using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Collections;

namespace FastFoodGame.Presentation
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Window
    {
        private ObservableCollection<User> _users;

        public UserManagement()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var input = new InputWindow("Name");
                input.Owner = this;

                if (input.ShowDialog().Value)
                {
                    UserController.AddUser(new User { Name = input.Value });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding new user: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lstUsers.SelectedIndex >= 0)
            {
                try
                {
                    var input = new InputWindow("Name");
                    input.Owner = this;

                    if (input.ShowDialog().Value)
                    {
                        var user = new User 
                        {
                            Name = input.Value,
                            Id = ((User)lstUsers.SelectedItem).Id
                        };

                        UserController.EditUser(user);
                        ((User)lstUsers.SelectedItem).Name = input.Value;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding new user: " + ex.Message);
                }
            }
        }

        private void UserManagement_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var users = UserController.GetAllUsers();

                if (users != null && users.Count > 0)
                {
                    lstUsers.ItemsSource = _users = new ObservableCollection<User>(users);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting users: " + ex.Message);
            }
        }
    }
}
