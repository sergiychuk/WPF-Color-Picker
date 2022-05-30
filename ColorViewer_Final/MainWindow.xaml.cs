using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ColorViewer_Final
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool ShowStartMessage = true;
        private ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
             
            if(ShowStartMessage == true)
                ShowInfoMessageOnStart();

            this.DataContext = viewModel;
        }

        private void Slider_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            // Get slider from sender
            Slider slider = sender as Slider;
            // Change slide value by mouse wheel
            if (slider != null)
            {
                if(e.Delta > 0)
                {
                    slider.Value += 1;
                }
                if(e.Delta < 0)
                {
                    slider.Value -= 1;
                }
                slider.Value = Math.Round(slider.Value);
            }   
        }

        private void ShowInfoMessageOnStart()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("- Значення слайдерерів можна також змінити колесом миші коли миша над слайдером");
            sb.AppendLine("- Колір виділення тексту в TextBox`ах різний в залежності від вибраного каналу");
            sb.AppendLine();
            sb.AppendLine("Головні кнопки все таки вирішив зробити резиновими");
            sb.AppendLine();
            sb.AppendLine("Що б вимкнути показ данного вікна при старті - вимкни bool`еву змінну \"ShowStartMessage\"!");
            MessageBox.Show(sb.ToString());
        }
    }
}
