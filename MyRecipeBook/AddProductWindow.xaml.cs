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
using static MyRecipeBook.MyFridgeWindow;

namespace MyRecipeBook
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Page
    {
        public ObservableCollection<BoolStringClass> TheList { get; private set; }

        public AddProductWindow()
        {
            InitializeComponent();
            CreateCheckBoxList();
        }

        public class BoolStringClass
        {
            public string TheText { get; set; }
            public int TheValue { get; set; }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MyFridgeWindow.xaml", UriKind.Relative));
        }

        public void CreateCheckBoxList()
        {
            TheList = new ObservableCollection<BoolStringClass>();
            TheList.Add(new BoolStringClass { TheText = "Chicken breast" });
            TheList.Add(new BoolStringClass { TheText = "Flour" });
            TheList.Add(new BoolStringClass { TheText = "Butter" });
            TheList.Add(new BoolStringClass { TheText = "Olive oil" });
            TheList.Add(new BoolStringClass { TheText = "Mushrooms" });
            TheList.Add(new BoolStringClass { TheText = "Salt" });
            TheList.Add(new BoolStringClass { TheText = "Milk" });
            TheList.Add(new BoolStringClass { TheText = "Vanilla Extract" });
            TheList.Add(new BoolStringClass { TheText = "Pound chicken" });
            TheList.Add(new BoolStringClass { TheText = "Maple syrup" });
            TheList.Add(new BoolStringClass { TheText = "Green onion" });
            TheList.Add(new BoolStringClass { TheText = "Vegetable oil" });
            TheList.Add(new BoolStringClass { TheText = "Biscuit dough" });
            TheList.Add(new BoolStringClass { TheText = "Eggs" });
            TheList.Add(new BoolStringClass { TheText = "Black pepper" });
            TheList.Add(new BoolStringClass { TheText = "Pork chops" });
            TheList.Add(new BoolStringClass { TheText = "Sugar" });
            TheList.Add(new BoolStringClass { TheText = "Cheese" });
            TheList.Add(new BoolStringClass { TheText = "Cinnamon" });
            TheList.Add(new BoolStringClass { TheText = "Paprika" });
            TheList.Add(new BoolStringClass { TheText = "Bacon" });
            this.DataContext = this;
        }
        
        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            if (products.Contains(chkZone.Content.ToString()) == false)
            {
                products.Add(chkZone.Content.ToString());
                productCount++;
            }          
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MyFridgeWindow.xaml", UriKind.Relative));
        }
    }
}
