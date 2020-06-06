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
    /// Логика взаимодействия для FormRecipesWindow.xaml
    /// </summary>
    public partial class FormRecipesWindow : Page
    {

        public static List<string> recipeNames = new List<string>();
        private List<string> recipeIngridients = new List<string>();
        private List<string> ingridientsArray;
        private string[] tmp;
        char[] charSeparators = new char[] { ',' };

        public FormRecipesWindow()
        {
            InitializeComponent();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("recipes.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            

            foreach (XmlNode xnode in xRoot)
            {             
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                    {
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "ingridients")
                            {
                                recipeIngridients.Add(childnode.InnerText);

                                for (int i = 0; i < recipeIngridients.Count; i++)
                                {
                                    tmp = recipeIngridients[i].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                                    ingridientsArray = new List<string>(tmp);
                                    int containsCount = 0;
                                    for (int j = 0; j < ingridientsArray.Count; j++)
                                    {
                                        for (int k = 0; k < MyFridgeWindow.products.Count; k++)
                                        {
                                            if (ingridientsArray[j].Contains(MyFridgeWindow.products[k]))
                                            {
                                                containsCount++;
                                            }
                                            if (containsCount == ingridientsArray.Count)
                                            {
                                                recipeNames.Add(attr.Value);
                                                listBox.Items.Add(attr.Value);
                                                ingridientsArray.Clear();
                                                recipeIngridients.Clear();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }                        
                        }
                    }
                }
            }
            
            if (listBox.Items.Count == 0)
            {
                label.Content = "   Unfortunately, you can't cook anything\n out of these foods. We recommended you\n                     to go on shopping :)";
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MyFridgeWindow.xaml", UriKind.Relative));
        }

        private void mainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }

        private void listBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
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
            catch (Exception)
            {
                listBox.SelectedItem = null;
            }
            
        }
    }
}
