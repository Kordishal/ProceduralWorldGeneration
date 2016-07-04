using ProceduralWorldGeneration.Elements;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Input;
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

        /// <summary>
        /// Stores certain top level values to invluence generation, which can be changed in the GUI.
        /// </summary>
        private ConfigValues GenerationConfigurations;

        /// <summary>
        /// The central class which holds the main creation loop, references to all the data classes and creates the primordial forces.
        /// </summary>
        private MythCreator MainMythCreationClass;
        

        public MainWindow()
        {
            InitializeComponent();
            GenerationConfigurations = new ConfigValues();
            MainMythCreationClass = new MythCreator();
            RandomSeedTextBox.DataContext = GenerationConfigurations;
        }

        private void WorldGenerationButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MythCreationButton_Click(object sender, RoutedEventArgs e)
        {
            MainMythCreationClass.InitializeMythCreation();
            ElementListView.DataContext = MainMythCreationClass.CreationMyths;
            ElementListView.ItemsSource = MainMythCreationClass.CreationMyths.MythObjects;       
            MainMythCreationClass.creationLoop();
            CreationMythTreeView.DataContext = MainMythCreationClass.CreationMyths;
            CreationMythTreeView.ItemsSource = MainMythCreationClass.CreationMyths.CreationTree.GetChildren();
        }

        private void ElementListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
            {
                return;
            }

            if (e.AddedItems[0].GetType() == typeof(BaseMythObject))
            {
                BaseMythObject myth_object = (BaseMythObject)e.AddedItems[0];
            }
             
        }
    }
}
