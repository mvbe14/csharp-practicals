using System;

namespace ClimateControlSystem
{
    public class TemperatureChangedEventArgs : EventArgs
    {
        public double Temperature { get; }

        public TemperatureChangedEventArgs(double temperature)
        {
            Temperature = temperature;
        }
    }
}
