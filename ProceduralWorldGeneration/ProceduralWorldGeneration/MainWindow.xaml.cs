using ProceduralWorldGeneration.Elements;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.Input.LexerDefinition;
using ProceduralWorldGeneration.Input.ParserDefinition;
using ProceduralWorldGeneration.MythObjects;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProceduralWorldGeneration
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MythCreator myth_creator;
        WorldGenerator world_generator;
        ConfigValues config;

        private int _generator;

        public MainWindow()
        {
            InitializeComponent();
            world_generator = new WorldGenerator();
            config = new ConfigValues();
            myth_creator = new MythCreator();
            SeedTextBox.DataContext = config;

            world_generator.endedGeneration += new WorldGenerator.EndedGeneration(WorldGenerationButton_Enable);



        }

        private void WorldGenerationButton_Click(object sender, RoutedEventArgs e)
        {
            _generator = 1;
            world_generator.InitializeWorldGenerator();
            ElementListView.DataContext = world_generator;
            ElementListView.ItemsSource = world_generator.GeneratedWorld.ElementCollection;
            WorldGenerationButton.IsEnabled = false;
            world_generator.generateWorld();
        }

        private void MythCreationButton_Click(object sender, RoutedEventArgs e)
        {
            _generator = 2;
            myth_creator.InitializeMythCreation();
            ElementListView.DataContext = myth_creator.CreationMyths;
            ElementListView.ItemsSource = myth_creator.CreationMyths.MythObjects;
            myth_creator.creationLoop();
        }

        private void WorldGenerationButton_Enable(string status)
        {
            this.WorldGenerationButton.IsEnabled = true;
        }

        private void ElementListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_generator == 1)
            {
                Element element = (Element)e.AddedItems[0];

                NameDisplayTextBlock.Text = element.Name;
                SizeDisplayTextBlock.Text = element.Size.ToString();
                if (element.ParentElement != null)
                    ParentNameDisplayTextBlock.Text = element.ParentElement.Name;
                else
                    ParentNameDisplayTextBlock.Text = "NONE";

                ChildrenElementListBox.DataContext = element;
                ChildrenElementListBox.ItemsSource = element.ChildElements;
            }
            else if (_generator == 2)
            {
                BaseMythObject myth_object = (BaseMythObject)e.AddedItems[0];
                NameDisplayTextBlock.Text = myth_object.Name;
            }

        }


    }
}
