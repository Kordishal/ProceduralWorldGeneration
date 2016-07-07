using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.Main;
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
        private ConfigValues _config;

        /// <summary>
        /// The data stored from the world state.
        /// </summary>
        private UserInterfaceData _user_interface_data;
        

        public MainWindow()
        {
            InitializeComponent();
            initialise();
        }

        private void initialise()
        {
            _config = new ConfigValues();
            RandomSeedTextBox.Text = _config.RandomSeed;
            _user_interface_data = new UserInterfaceData();
        }

        private void MythCreationButton_Click(object sender, RoutedEventArgs e)
        {
            Programm.initialise(_user_interface_data);
            Programm.startCreationLoop();
            ElementListView.DataContext = _user_interface_data;
            ElementListView.ItemsSource = _user_interface_data.MythObjects;
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
