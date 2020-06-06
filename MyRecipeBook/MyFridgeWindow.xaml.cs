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

namespace MyRecipeBook
{
    /// <summary>
    /// Логика взаимодействия для MyFridgeWindow.xaml
    /// </summary>
    public partial class MyFridgeWindow : Page
    {
        public static List<string> products = new List<string>();
        public static int productCount;

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AddProductWindow.xaml", UriKind.Relative));
        }

        public MyFridgeWindow()
        {
            InitializeComponent();
            for (int i = 0; i < products.Count; i++)
            {
                listBox.Items.Add(products[i]);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                int del = listBox.SelectedIndex;
                listBox.Items.RemoveAt(del);
                products.RemoveAt(del);
                label.Content = "";
            }
            else
            {
                label.Content = "If you want to delete product, please select it.";
            }
        }

        private void formRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.Items.Count != 0)
            {
                this.NavigationService.Navigate(new Uri("FormRecipesWindow.xaml", UriKind.Relative));
            }
            else
            {
                label.Content = "You do not have a single product in the fridge.";
            }
        }
    }
}
