using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
//using System.Drawing;


namespace Color_Viewer
{
    public class ViewModel 
    {
        private readonly ICollection<CustomColor> colors = new ObservableCollection<CustomColor>();
        
        // FIXME: remove adding color objects on start(!!colors list must be empty on start!!) ]
        public ViewModel()
        {
            colors.Add(new CustomColor() { Red = 255, Green = 255, Blue = 255, Alpha = 255 });
            colors.Add(new CustomColor() { Red = 0, Green = 0, Blue = 255, Alpha = 255 });
            colors.Add(new CustomColor() { Red = 0, Green = 255, Blue = 0, Alpha = 255 });
            colors.Add(new CustomColor() { Red = 255, Green = 0, Blue = 0, Alpha = 255 });
        }

        // Property to bind to the color list
        public IEnumerable<CustomColor> Colors => colors;

        // Property to bind to the choosed color from list
        public CustomColor SelectedColor { get; set; }

        // Property to bind to the color box
        public Color CurrentColor 
        {
            get
            {
                return Color.FromArgb((byte)SelectedColor.Alpha, (byte)SelectedColor.Red, (byte)SelectedColor.Green, (byte)SelectedColor.Blue);
                //return colors[SelectedColor];
                //return Color.FromArgb((byte)SelectedColor.Alpha, (byte)SelectedColor.Red, (byte)SelectedColor.Green, (byte)SelectedColor.Blue);
                //return (Color)ColorConverter.ConvertFromString(Color.FromArgb((byte)SelectedColor.Alpha, (byte)SelectedColor.Red, (byte)SelectedColor.Green, (byte)SelectedColor.Blue).ToString());
            }
        }
        //public System.Windows.Media.Color CurrentColor => System.Windows.Media.Color.FromArgb((byte)SelectedColor.Alpha,
        //    (byte)SelectedColor.Red,
        //    (byte)SelectedColor.Green,
        //    (byte)SelectedColor.Blue);

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
                    Alpha = 100
                });
            }
        }

        public void RemoveSelectedColor()
        {
            if (SelectedColor != null)
            {
                colors.Remove(SelectedColor);
            }
        }
    }
}
