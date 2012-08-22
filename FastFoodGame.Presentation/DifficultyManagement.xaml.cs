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
using System.Xml;
using FastFoodGame.BusinessLayer;
using FastFoodGame.Framework;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.ObjectModel;

namespace FastFoodGame.Presentation
{
    /// <summary>
    /// Interaction logic for DifficultyManagement.xaml
    /// </summary>
    public partial class DifficultyManagement : Window
    {
        private ObservableCollection<Difficulty> _difficulties;

        public DifficultyManagement()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var fail = false;
            int maxSandwich, minSandwich, maxTime, minTime;

            if (!int.TryParse(txtMaxPerSandwich.Text, out maxSandwich))
            {
                fail = true;
            }
            if (!int.TryParse(txtMinPerSandwich.Text, out minSandwich))
            {
                fail = true;
            }
            if (!int.TryParse(txtMaxTimePerOrder.Text, out maxTime))
            {
                fail = true;
            }
            if (!int.TryParse(txtMinTimePerOrder.Text, out minTime))
            {
                fail = true;
            }

            if (fail)
            {
                MessageBox.Show("Invalid input!");
                return;
            }

            var diff = new Difficulty
            {
                Name = cboDifficulties.Text,
                MaxNumberOfSandwiches = maxSandwich,
                MinNumberOfSandwiches = minSandwich,
                MaxTimeBetweenOrders = maxTime,
                MinTimeBetweenOrders = minTime
            };

            if (cboDifficulties.SelectedIndex >= 0)
            {
                try
                {
                    diff.Id = (cboDifficulties.SelectedItem as Difficulty).Id;
                    DifficultyController.EditDifficulty(diff);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error modifying difficulty: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    DifficultyController.AddDifficulty(diff);
                    _difficulties.Add(diff);
                    MessageBox.Show("Added difficulty!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding difficulty: " + ex.Message);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var difficulties = DifficultyController.GetAllDifficulties();
                

                if (difficulties != null && difficulties.Count > 0)
                {
                    cboDifficulties.ItemsSource = _difficulties = new ObservableCollection<Difficulty>(difficulties);
                    cboDifficulties.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting difficulties: " + ex.Message);
            }
        }

        private void cboDifficulties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboDifficulties.SelectedIndex >= 0)
            {
                Difficulty dif;
                if ((dif = cboDifficulties.SelectedItem as Difficulty) != null)
                {
                    txtMaxPerSandwich.Text = dif.MaxNumberOfSandwiches.ToString();
                    txtMinPerSandwich.Text = dif.MinNumberOfSandwiches.ToString();
                    txtMaxTimePerOrder.Text = dif.MaxTimeBetweenOrders.ToString();
                    txtMinTimePerOrder.Text = dif.MinTimeBetweenOrders.ToString();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            cboDifficulties.SelectedIndex = -1;
            txtMaxPerSandwich.Text = string.Empty;
            txtMaxTimePerOrder.Text = string.Empty;
            txtMinPerSandwich.Text = string.Empty;
            txtMinTimePerOrder.Text = string.Empty;
            cboDifficulties.Text = string.Empty;
            cboDifficulties.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
