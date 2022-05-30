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
        private CustomColor selectedColor;

        // Observable collection of colors for dynamicly update UI
        private readonly ICollection<CustomColor> colors = new ObservableCollection<CustomColor>();

        // Copy color command delegat
        private readonly RelayCommand copyCommand;
        private readonly RelayCommand removeCommand;
        private readonly RelayCommand increaseAlphaCommand;

        // Default constructor 
        public ViewModel()
        {
            // Adding a bunch of colors to the list when initializing the class
            colors.Add(new CustomColor() { Red = 255, Green = 0, Blue = 0, Alpha = 255 });      // Red
            colors.Add(new CustomColor() { Red = 0, Green = 255, Blue = 0, Alpha = 255 });      // Green
            colors.Add(new CustomColor() { Red = 0, Green = 0, Blue = 255, Alpha = 255 });      // Blue
            //colors.Add(new CustomColor() { Red = 0, Green = 0, Blue = 0, Alpha = 255 });        // Black
            //colors.Add(new CustomColor() { Red = 255, Green = 255, Blue = 255, Alpha = 255 });  // White
            //colors.Add(new CustomColor() { Red = 255, Green = 255, Blue = 255, Alpha = 125 });  // Gray

            // Set SelectedColor to new if it was not set(if null)
            SelectedColor = SelectedColor ?? new CustomColor();

            // Set delegate for copying colors command
            copyCommand = new RelayCommand((o) => DublicateSelectedColor());
            removeCommand = new RelayCommand((o) => RemoveSelectedColor());
            increaseAlphaCommand = new RelayCommand((o) => IncreaseAlpha());
        }



        // Property to bind to the list of colors
        public IEnumerable<CustomColor> Colors => colors;

        // Property to bind to the choosed color from list
        public CustomColor SelectedColor
        {
            get => selectedColor;
            set
            {
                // Sets the selected color only if current selected is not eq to given in value color 
                if (selectedColor != value)
                {
                    selectedColor = value;
                    //OnPropertyChanged();
                }
            }
        }

        // Properties for binding commands
        public ICommand CopyColorCmd => (ICommand)copyCommand;
        public ICommand RemoveColorCmd => (ICommand)removeCommand;

        // Copies selected color to colors list as new color object
        public void DublicateSelectedColor()
        {
            // Clone SelectedColor object if it not null
            if (SelectedColor != null)
            {
                colors.Add((CustomColor)SelectedColor.Clone());
            }

            // Otherwise put newly created color object
            if(SelectedColor == null)
            {
                colors.Add(new CustomColor());
            }
        }

        // Removes selected color from list
        public void RemoveSelectedColor()
        {
            // If selected color not null
            if (SelectedColor != null)
            {
                colors.Remove(SelectedColor);
            }
        }

        public void IncreaseAlpha()
        {
            SelectedColor.Alpha += 1;
        }
        
    }
}
