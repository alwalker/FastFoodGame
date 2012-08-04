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

namespace FastFoodGame.Presentation
{
    /// <summary>
    /// Interaction logic for DifficultyManagement.xaml
    /// </summary>
    public partial class DifficultyManagement : Window
    {
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

            try
            {
                DifficultyController.AddDifficulty(
                    new Difficulty
                    {
                        Name = cboDifficulties.Text,
                        MaxNumberOfSandwiches = maxSandwich,
                        MinNumberOfSandwiches = minSandwich,
                        MaxTimeBetweenOrders = maxTime,
                        MinTimeBetweenOrders = minTime
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding difficulty: " + ex.Message);
            }
        }
    }
}
