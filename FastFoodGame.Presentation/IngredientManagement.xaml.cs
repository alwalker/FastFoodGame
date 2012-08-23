using FastFoodGame.BusinessLayer;
using FastFoodGame.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml;

namespace FastFoodGame.Presentation
{
    /// <summary>
    /// Interaction logic for IngredientManagement.xaml
    /// </summary>
    public partial class IngredientManagement : Window
    {
        private ObservableCollection<Ingredient> _ingredients;

        public IngredientManagement()
        {
            InitializeComponent();
        }

        private void cboIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboIngredients.SelectedIndex >= 0)
            {
                var ingredient = cboIngredients.SelectedItem as Ingredient;

                txtContainerRefilTime.Text = ingredient.ContainerRefilTime.ToString();
                txtLifeSpan.Text = ingredient.LifeSpan.ToString();
                txtSingleContainerCapacity.Text = ingredient.SingleContainerCapacity.ToString();
                cboType.SelectedIndex = (int)ingredient.Type;
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            cboIngredients.SelectedIndex = -1;
            txtSingleContainerCapacity.Text = string.Empty;
            txtLifeSpan.Text = string.Empty;
            txtContainerRefilTime.Text = string.Empty;
            cboType.SelectedIndex = -1;
            cboIngredients.Text = string.Empty;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var ingredient = new Ingredient
            {
                Name = cboIngredients.Text,
                SingleContainerCapacity = Convert.ToInt32(txtSingleContainerCapacity.Text),
                LifeSpan = Convert.ToInt32(txtLifeSpan.Text),
                ContainerRefilTime = Convert.ToInt32(txtContainerRefilTime.Text),
                Type = (Ingredient.IngredientType)cboType.SelectedIndex
            };

            if (cboIngredients.SelectedIndex < 0)
            {
                try
                {
                    IngredientController.AddIngredient(ingredient);
                    MessageBox.Show("Saved new ingredient!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding new ingredient: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    ingredient.Id = ((Ingredient)cboIngredients.SelectedItem).Id;

                    IngredientController.EditIngredient(ingredient);
                    MessageBox.Show("Updated ingredient!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating ingredient: " + ex.Message);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var ingredients = IngredientController.GetAllIngredients();

                if (ingredients != null && ingredients.Count > 0)
                {
                    _ingredients = new ObservableCollection<Ingredient>(ingredients);
                    cboIngredients.ItemsSource = _ingredients;
                    cboIngredients.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting ingredients: " + ex.Message);
            }

            cboType.ItemsSource = Enum.GetValues(typeof(Ingredient.IngredientType));
            cboType.SelectedIndex = 1;
        }
    }
}
