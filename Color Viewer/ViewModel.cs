//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Media;
//using System.Windows.Input;
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


namespace Color_Viewer
{
    public class ViewModel
    {
        private CustomColor selectedColor = new();
        private readonly ICollection<CustomColor> colors = new ObservableCollection<CustomColor>();

        // Commands
        // Приватне поле команд
        private RelayCommand copyCommand;

        // FIXME: remove adding color objects on start(!!colors list must be empty on start!!) ]
        public ViewModel()
        {
            colors.Add(new CustomColor() { Red = 0, Green = 0, Blue = 0, Alpha = 255 });        // Black
            colors.Add(new CustomColor() { Red = 255, Green = 255, Blue = 255, Alpha = 255 });  // White
            colors.Add(new CustomColor() { Red = 0, Green = 0, Blue = 255, Alpha = 255 });      // Blue
            colors.Add(new CustomColor() { Red = 0, Green = 255, Blue = 0, Alpha = 255 });      // Green
            colors.Add(new CustomColor() { Red = 255, Green = 0, Blue = 0, Alpha = 255 });      // Red
            MessageBox.Show($"{SelectedColor}");

            copyCommand = new RelayCommand((o) => DublicateSelectedColor());
        }

        // Property to bind to the color list
        public IEnumerable<CustomColor> Colors => colors;

        // Propertyies to bind commands to buttons

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
        public ICommand CopyCmd => (ICommand)copyCommand;


        private bool IsNewColor(object obj)
        {
            foreach (CustomColor col in Colors)
            {
                if(col.Red == SelectedColor.Red && col.Green == SelectedColor.Green && col.Blue == SelectedColor.Blue && col.Alpha == SelectedColor.Alpha)
                {
                    return false;
                }
                //if (col.Red == SelectedColor.Red || col.Green == SelectedColor.Green || col.Blue == SelectedColor.Blue || col.Alpha == SelectedColor.Alpha)
                //{
                //    return false;
                //}
                //return col.Equals(SelectedColor);
            }
            return true;
        }
        public bool IsSelectedColor(object obj)
        {
            return SelectedColor != null;
        }
        

        public void DublicateSelectedColor()
        {
            if (SelectedColor != null)
            {
                colors.Add(new CustomColor()
                {
                    Red = SelectedColor.Red,
                    Green = SelectedColor.Green,
                    Blue = SelectedColor.Blue,
                    Alpha = SelectedColor.Alpha
                });
                //colors.Add((Color)SelectedColor.Clone());
            }
            else
            {
                colors.Add(new CustomColor()
                {
                    Red = 0,
                    Green = 0,
                    Blue = 0,
                    Alpha = 255
                });
            }
        }
        public void RemoveSelectedColor()
        {
            MessageBox.Show($"SelectedColor: {SelectedColor}");
            if(SelectedColor != null)
                colors.Remove(SelectedColor);
        }
    }
}
