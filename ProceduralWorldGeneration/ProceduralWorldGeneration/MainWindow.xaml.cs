using ProceduralWorldGeneration.Generator;
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
        WorldGenerator world_generator;

        public MainWindow()
        {
            InitializeComponent();
            world_generator = new WorldGenerator();
            world_generator.createdNewElement += new WorldGenerator.CreatedNewElement(UpdateGenerationLog);

            SeedTextBox.DataContext = world_generator;
        }

        private void WorldGenerationButton_Click(object sender, RoutedEventArgs e)
        {
            world_generator.generateWorld();
            this.WorldGenerationButton.IsEnabled = false;
        }

        private void UpdateGenerationLog(string status)
        {
            GenerationLog.AppendText(status);
        }

    }
}
