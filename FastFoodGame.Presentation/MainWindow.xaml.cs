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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFoodGame.Presentation
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

        private void btnConfigureDifficulties_Click(object sender, RoutedEventArgs e)
        {
            var difficultyManagement = new DifficultyManagement();
            difficultyManagement.Owner = this;
            difficultyManagement.ShowDialog();
        }

        private void btnManageUsers_Click(object sender, RoutedEventArgs e)
        {
            var userManagement = new UserManagement();
            userManagement.Owner = this;
            userManagement.ShowDialog();
        }

        private void btnManageIngredients_Click(object sender, RoutedEventArgs e)
        {
            var ingredientManagement = new IngredientManagement();
            ingredientManagement.Owner = this;
            ingredientManagement.ShowDialog();
        }
    }
}
