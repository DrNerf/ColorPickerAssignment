using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorPicker.Classes.ViewModels
{
    public class ColorViewModel : INotifyPropertyChanged
    {
        public const int MaxRGBValue = 255;
        public const int MinRGBValue = 0;
        public ColorCommand ColorCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public ColorViewModel()
        {
            ColorCommand = new ColorCommand(this);
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private void NotifyColorChanged([CallerMemberName] String propertyName = "")
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged("Result");
            OnPropertyChanged("ResultColor");
        }

        private int _Red = 0;

        public int Red
        {
            get { return _Red; }
            set
            {
                _Red = ValidateRGBValue(value);
                NotifyColorChanged();
            }
        }

        private int _Blue = 0;

        public int Blue
        {
            get { return _Blue; }
            set
            {
                _Blue = ValidateRGBValue(value);
                NotifyColorChanged();
            }
        }

        private int _Green = 0;

        public int Green
        {
            get { return _Green; }
            set
            {
                _Green = ValidateRGBValue(value);
                NotifyColorChanged();
            }
        }

        public string Result
        {
            get
            {
                return Red.ToString("X2") + Green.ToString("X2") + Blue.ToString("X2");
            }
            private set { }
        }

        public string ResultColor
        {
            get
            {
                return "#" + Red.ToString("X2") + Green.ToString("X2") + Blue.ToString("X2");
            }
            private set { }
        }

        private int ValidateRGBValue(int value)
        {
            if (value > MaxRGBValue)
                value = MaxRGBValue;
            else if (value < MinRGBValue)
                value = MinRGBValue;
            return value;
        }

        public void SetHexColor(string color)
        {
            var rgbColor = (Color)ColorConverter.ConvertFromString(color);
            Red = rgbColor.R;
            Green = rgbColor.G;
            Blue = rgbColor.B;
        }

    }
}
