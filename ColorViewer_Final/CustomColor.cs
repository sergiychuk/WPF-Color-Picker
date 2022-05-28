using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//using System.Drawing;
using System.Windows.Media;


namespace ColorViewer_Final
{
    public class CustomColor : INotifyPropertyChanged
    {
        #region -----[Private color variables]-----
        private int red;
        private int green;
        private int blue;
        private int alpha;
        #endregion

        #region -----[Colors properties]------
        public int Red
        {
            get { return red; }
            set
            {
                if (red != value)
                {
                    red = ChannelRangeCorrection(value);
                    //red = value;
                    //OnPropertyChanged();
                    //OnPropertyChanged(nameof(SystemColor));
                    //OnPropertyChanged(nameof(Code));
                    UpdateChangedColorValues();
                }
            }
        }
        public int Green {
            get { return green; }
            set
            {
                if (green != value)
                {
                    green = ChannelRangeCorrection(value);
                    //green = value;
                    //OnPropertyChanged();
                    //OnPropertyChanged(nameof(SystemColor));
                    //OnPropertyChanged(nameof(Code));
                    UpdateChangedColorValues();
                }
            }
        }
        public int Blue {
            get { return blue; }
            set
            {
                if (blue != value)
                {
                    blue = ChannelRangeCorrection(value);
                    //blue = value;
                    //OnPropertyChanged();
                    //OnPropertyChanged(nameof(SystemColor));
                    //OnPropertyChanged(nameof(Code));
                    UpdateChangedColorValues();
                }
            }
        }
        public int Alpha
        {
            get { return alpha; }
            set
            {
                if (alpha != value)
                {
                    alpha = ChannelRangeCorrection(value);
                    //alpha = value;
                    //OnPropertyChanged();
                    //OnPropertyChanged(nameof(SystemColor));
                    //OnPropertyChanged(nameof(Code));
                    UpdateChangedColorValues();
                }
            }
        }
        #endregion

        public CustomColor(int r = 0, int g = 0, int b = 0, int a = 0)
        {
            Red = r;
            Green = g;
            Blue = b;
            Alpha = a;
        }

        public Color SystemColor => Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue);
        public string Code => $"{SystemColor} - [{Red}; {Green}; {Blue}; {Alpha}]";
        public string RGBA => $"[{Red}; {Green}; {Blue}; {Alpha}]";
        public string Hex => $"{SystemColor}";


        public object Clone()
        {
            return (CustomColor)this.MemberwiseClone();
        }

        // Оголошення події оновлення властивості
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int ChannelRangeCorrection(int value)
        {
            return (value > 255) ? 255 : (value < 0 ? 0 : value);
        }

        private void UpdateChangedColorValues()
        {
            OnPropertyChanged();
            OnPropertyChanged(nameof(SystemColor));
            OnPropertyChanged(nameof(Code));
            OnPropertyChanged(nameof(RGBA));
            OnPropertyChanged(nameof(Hex));
        }
    }
}
