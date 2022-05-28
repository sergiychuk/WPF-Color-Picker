using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//using System.Drawing;
using System.Windows.Media;


namespace Color_Viewer
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
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SystemColor));
                    OnPropertyChanged(nameof(Code));
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
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SystemColor));
                    OnPropertyChanged(nameof(Code));
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
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SystemColor));
                    OnPropertyChanged(nameof(Code));
                }
            }
        }
        #endregion

        public Color SystemColor => Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue);
        public string Code => SystemColor.ToString();


        public object Clone()
        {
            return (CustomColor)this.MemberwiseClone();
        }

        // Оголошення події оновлення властивості
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int ChannelRangeCorrection(int value)
        {
            return (value > 255) ? 255 : (value < 0 ? 0 : value);
        }
    }
}
