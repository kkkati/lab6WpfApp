using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab6WpfApp
{
    class WeatherControl : DependencyObject
    {
        private string napravlenieVetra;
        private int speedVeter;
        private int osadki;

        public string NapravlenieVetra
        {
            get => napravlenieVetra;
            set => napravlenieVetra = value;
        }
        public int SpeedVeter
        {
            get => speedVeter;
            set
            {
                if (value > 0)
                    speedVeter = value;
                else
                    speedVeter = 0;
            }
        }
        public int Osadki
        {
            get => osadki;
            set
            {
                switch (osadki)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                }
            }
        }
        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty,value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int t = (int)value;
            if (t >= -50 && t < 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t < 50)
                return t;
            else
                return 0;
        }
    }
}
