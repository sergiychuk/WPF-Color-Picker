using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ColorViewer_Final
{
    public class ViewModel
    {
        private CustomColor selectedColor = new CustomColor();
        private readonly ICollection<CustomColor> colors = new ObservableCollection<CustomColor>();

        private RelayCommand copyCommand;

        public ViewModel()
        {
            colors.Add(new CustomColor() { Red = 255, Green = 0, Blue = 0, Alpha = 255 });      // Red
            colors.Add(new CustomColor() { Red = 0, Green = 255, Blue = 0, Alpha = 255 });      // Green
            colors.Add(new CustomColor() { Red = 0, Green = 0, Blue = 255, Alpha = 255 });      // Blue
            colors.Add(new CustomColor() { Red = 0, Green = 0, Blue = 0, Alpha = 255 });        // Black
            colors.Add(new CustomColor() { Red = 255, Green = 255, Blue = 255, Alpha = 255 });  // White
            colors.Add(new CustomColor() { Red = 255, Green = 255, Blue = 255, Alpha = 125 });  // Gray

            copyCommand = new RelayCommand((o) => DublicateSelectedColor());
        }

        // Property to bind to the color list
        public IEnumerable<CustomColor> Colors => colors;

        // Property to bind to the choosed color from list
        public CustomColor SelectedColor
        {
            get => selectedColor;
            set
            {
                selectedColor = value;
                //OnPropertyChanged();
            }
        }

        // Властивості команд для прив'язки
        public ICommand CopyColorCmd => (ICommand)copyCommand;

        public void DublicateSelectedColor()
        {
            if (SelectedColor != null)
            {
                //colors.Add(new CustomColor()
                //{
                //    Red = SelectedColor.Red,
                //    Green = SelectedColor.Green,
                //    Blue = SelectedColor.Blue,
                //    Alpha = SelectedColor.Alpha
                //});
                colors.Add((CustomColor)SelectedColor.Clone());
            }
            else if(SelectedColor == null)
            {
                colors.Add(new CustomColor());
            }
        }
        public void RemoveSelectedColor()
        {
            MessageBox.Show($"SelectedColor: {SelectedColor}");
            if (SelectedColor != null)
                colors.Remove(SelectedColor);
        }
    }
}
