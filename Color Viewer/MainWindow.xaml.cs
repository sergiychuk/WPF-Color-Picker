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

namespace Color_Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Data model to display in UI
        private readonly ViewModel viewModel = new();

        #region [Window Initializing]
        public MainWindow()
        {
            InitializeComponent();

            // Data context with properties for window UI
            this.DataContext = viewModel;

            // Set first element in colors list as selected 
            MessageBox.Show($"Selected color list index: {colorsListBox.SelectedIndex}");
        }
        #endregion

        #region [Buttons click event handlers]
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DublicateSelectedColor();
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveSelectedColor();
        }
        #endregion

        #region ====>[DEBUGGING]<====

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show($"Current color: {viewModel.CurrentColor}");
        }
        #endregion

        private void borderColorDisplay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show($"borderColorDisplay.Background: {borderColorDisplay.Background}");
            //borderColorDisplay.Background = new SolidColorBrush(viewModel.SelectedColor.SystemColor);
        }
    }
}
