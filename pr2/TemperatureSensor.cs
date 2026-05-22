using System;

namespace ClimateControlSystem
{
    public class TemperatureSensor
    {
        private double _currentTemperature;

        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        public double Temperature
        {
            get => _currentTemperature;
            set
            {
                if (Math.Abs(_currentTemperature - value) > 0.01)
                {
                    _currentTemperature = value;
                    OnTemperatureChanged(new TemperatureChangedEventArgs(_currentTemperature));
                }
            }
        }

        protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }
    }
}
