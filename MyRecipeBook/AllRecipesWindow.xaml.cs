using System;
using System.Collections.Generic;
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

namespace MyRecipeBook
{
    /// <summary>
    /// Логика взаимодействия для AllRecipesWindow.xaml
    /// </summary>
    public partial class AllRecipesWindow : Page
    {

        public static List<string> recipeNames = new List<string>();

        public AllRecipesWindow()
        {
            InitializeComponent();
            recipeNames.Clear();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("recipes.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            int i = 0;
            foreach (XmlNode xnode in xRoot)
            { 
                if (xnode.Attributes.Count > 0)
                {                 
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                    {
                        recipeNames.Add(attr.Value);
                        i++;
                    }
                }
            }
            for (int j = 0; j < recipeNames.Count; j++)
            {
                listBox.Items.Add(recipeNames[j]);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
            
        }

    
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                for (int i = 0; i < recipeNames.Count; i++)
                {
                    if (listBox.SelectedItem.ToString() == recipeNames[i])
                    {
                        RecipeWindow.recipe = recipeNames[i];
                        this.NavigationService.Navigate(new Uri("RecipeWindow.xaml", UriKind.Relative));
                        break;
                    }
                }
            }
            catch(Exception)
            {
                listBox.SelectedItem = null;
            }
                      
        }
    }
}
