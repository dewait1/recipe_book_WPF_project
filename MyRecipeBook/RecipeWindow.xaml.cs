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
    /// Логика взаимодействия для RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Page
    {
        public static string recipe;
        private string imgSrc;

        public RecipeWindow()
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
                        if (attr.Value == recipe)
                        {
                            textBlock.Text = attr.Value;
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                if (childnode.Name == "imgurl")
                                {
                                    imgSrc = childnode.InnerText;
                                }
                                if (childnode.Name == "ingridients")
                                {
                                    textBlock1.Text = childnode.InnerText;
                                }
                                if (childnode.Name == "description")
                                {
                                    textBlock2.Text = childnode.InnerText;
                                }
                            }
                            break;
                        }                      
                    }
                }   
            }
            var bi = new System.Windows.Media.Imaging.BitmapImage(new Uri(imgSrc));
            img.Source = bi;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AllRecipesWindow.xaml", UriKind.Relative));
        }

        private void mainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }
    }
}
