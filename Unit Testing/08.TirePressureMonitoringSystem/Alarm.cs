public class Alarm
{
    private const double LowPressureThreshold = 17;
    private const double HighPressureThreshold = 21;

    private readonly Sensor sensor = new Sensor();

    private bool alarmOn = false;

    public void Check()
    {
        double psiPressureValue = this.sensor.PopNextPressurePsiValue();

        if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
        {
            this.alarmOn = true;
        }
    }

    public bool AlarmOn => this.alarmOn;
}

