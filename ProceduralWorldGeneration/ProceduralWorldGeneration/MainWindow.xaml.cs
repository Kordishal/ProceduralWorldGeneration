using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Main;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// The data stored from the world state.
        /// </summary>
        private UserInterfaceData _user_interface_data;
        

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        private void Initialise()
        {
            Program.InitialiseData();
            domainDataGrid.DataContext = Program.DataLoadHandler.Domains;

            planeElementDataGrid.DataContext = Program.DataLoadHandler.PlaneElements;
            planeSizeDataGrid.DataContext = Program.DataLoadHandler.PlaneSizes;
            planeTypeDataGrid.DataContext = Program.DataLoadHandler.PlaneTypes;
            speciesTypeDataGrid.DataContext = Program.DataLoadHandler.SpeciesTypes;
            speciesTraitDataGrid.DataContext = Program.DataLoadHandler.SpeciesTraits;
            traitCategoriesDataGrid.DataContext = Program.DataLoadHandler.TraitCategories;

            Program.GeneratorConfigurations = new ConfigValues();
            RandomSeedTextBox.Text = Program.GeneratorConfigurations.RandomSeed;
            _user_interface_data = new UserInterfaceData();
        }

        private void MythCreationButton_Click(object sender, RoutedEventArgs e)
        {
            Program.Initialise(_user_interface_data);
            Program.StartCreationLoop();
            ElementListView.DataContext = _user_interface_data;
            ElementListView.ItemsSource = _user_interface_data.MythObjects;
        }

        private void ElementListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
            {
                return;
            }

            BaseMythObject myth_object = (BaseMythObject)e.AddedItems[0];
            textBlock_name_value.Text = myth_object.Name;
            textBlock_tag_value.Text = myth_object.Tag;
            textBlock_identifier_value.Text = myth_object.Identifier.ToString();

            if (myth_object.Creator != null)
            {
                textBlock_creator_value.Text = myth_object.Creator.ToString();
            }
            else
            {
                textBlock_creator_value.Text = "NONE";
            }

            if (e.AddedItems[0].GetType() == typeof(PrimordialForce))
            {

            }
            else if (e.AddedItems[0].GetType() == typeof(Plane))
            {
                Plane plane = (Plane)e.AddedItems[0];

                LabelOtherInformation.Content = "Plane Information";

                textBlock_other1.Text = "Plane Type: ";
                if (plane.PlaneType != null)
                    textBlock_other1_value.Text = plane.PlaneType.ToString();
                else
                    textBlock_other1_value.Text = "NONE";

                textBlock_other2.Text = "Plane Size: ";
                if (plane.PlaneSize != null)
                    textBlock_other2_value.Text = plane.PlaneSize.ToString();
                else
                    textBlock_other2_value.Text = "NONE";

                textBlock_other3.Text = "Plane Element: ";
                if (plane.PlaneElement != null)
                    textBlock_other3_value.Text = plane.PlaneElement.ToString();
                else
                    textBlock_other3_value.Text = "NONE";

                listBox_other.ItemsSource = plane.NeighbourPlanes;
            }
            else if (e.AddedItems[0].GetType() == typeof(Deity))
            {
                Deity deity = (Deity)e.AddedItems[0];

                LabelOtherInformation.Content = "Deity Information";

                textBlock_other1.Text = "Personality: ";
                textBlock_other1_value.Text = deity.Personality.Name;
                textBlock_other2.Text = "Power: ";
                textBlock_other2_value.Text = deity.Power.ToString();


                listBox_other.ItemsSource = deity.Domains;
            }
             
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource domainViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("domainViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // domainViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource planeElementViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("planeElementViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // planeElementViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource planeSizeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("planeSizeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // planeSizeViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource planeTypeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("planeTypeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // planeTypeViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource speciesTypeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("speciesTypeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // speciesTypeViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource speciesTraitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("speciesTraitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // speciesTraitViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource traitCategoriesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("traitCategoriesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // traitCategoriesViewSource.Source = [generic data source]
        }
    }
}
