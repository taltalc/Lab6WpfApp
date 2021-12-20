using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework
{
    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string windvector;
        private int windspeed;

        public string WindVector
        {
            get { return windvector; }
            set { windvector = value; }
        }
        public int WindSpeed
        {
            get { return windspeed; }
            set
            {
                if (value >= 0)
                {
                    windspeed = value;
                }
                else
                {
                    windspeed = 0;
                }
            }
        }
        public enum Precipition
        {
            [Description("Солнечно")]
            ItemOne = 0,
            [Description("Облачно")]
            ItemTwo = 1,
            [Description("Дождь")]
            ItemThree = 2,
            [Description("Снег")]
            ItemFour = 3,
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(

                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                new CoerceValueCallback(CoerceTemperature)));

               
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int temperature = (int) baseValue;
            if (temperature >= -50 && temperature <= 50)
            {
                return temperature;
            }
            else
            {
                return 0;
            }
        }
    }
}
