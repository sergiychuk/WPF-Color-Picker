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
    public class CustomColor: INotifyPropertyChanged
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
                if(red != value)
                {
                    red = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Green {
            get { return green; }
            set
            {
                if (green != value)
                {
                    green = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Blue { 
            get { return blue; }
            set
            {
                if(blue != value)
                {
                    blue = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Alpha
        {
            get { return alpha; }
            set
            {
                if(alpha != value)
                {
                    alpha = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        //==============================================================
        //==============>[FixMe: fix or delete DEEP copy]<==============
        public object Clone()
        {
            // shallow copy (поверхневе копіювання) - копіюються значення value типів та посилання reference типів
            CustomColor clone = (CustomColor)this.MemberwiseClone();

            // deep copy (глибоке копіювання) - кожний reference тип копіюється власним методом клонування
            //clone.Red = this.Clone();
            //clone.Green = Green.Clone();
            //clone.Blue = (int)this.Blue.Clone();

            return clone;
        }
        //==============================================================

        // Оголошення події оновлення властивості
        public event PropertyChangedEventHandler PropertyChanged;

        // Створення методу OnPropertyChanged для виклику події
        // В якості параметра буде використано ім'я властивості, що його викликала
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //==============>[TODO: ask how update listbox item if color data was changed]<============
        public override string ToString()
        {
            return $"{Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue)}";
        }
    }
}
