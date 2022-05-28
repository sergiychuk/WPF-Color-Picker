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
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SystemColor));
                    OnPropertyChanged(nameof(Code));
                    OnPropertyChanged(nameof(ARGB));
                    OnPropertyChanged(nameof(HEX));
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
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SystemColor));
                    OnPropertyChanged(nameof(Code));
                    OnPropertyChanged(nameof(ARGB));
                    OnPropertyChanged(nameof(HEX));
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
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SystemColor));
                    OnPropertyChanged(nameof(Code));
                    OnPropertyChanged(nameof(ARGB));
                    OnPropertyChanged(nameof(HEX));
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
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SystemColor));
                    OnPropertyChanged(nameof(Code));
                    OnPropertyChanged(nameof(ARGB));
                    OnPropertyChanged(nameof(HEX));
                }
            }
        }
        #endregion

        //public CustomColor(int r = null, int g = null, int b = null, int a = null)
        //{
        //    Red = r == null ? 0 : r;
        //    Green = g == null ? 0 : g;
        //    Blue = b == null ? 0 : b;
        //    Alpha = a == null ? 0 : a;
        //}

        public Color SystemColor => Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue);
        public string Code => $"{SystemColor} - [{Alpha}; {Red}; {Green}; {Blue}]";
        public string ARGB => $"[{Alpha}; {Red}; {Green}; {Blue}]";
        public string HEX => $"{SystemColor}";


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
            OnPropertyChanged(nameof(ARGB));
            OnPropertyChanged(nameof(HEX));
        }
    }
}
