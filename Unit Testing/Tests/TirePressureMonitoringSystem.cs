using Moq;
using NUnit.Framework;

public class TirePressureMonitoringSystem
{
    [Test]
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(16)]
    [TestCase(20)]
    public void CheckIfAlarmIsOn(double expected)
    {
        var sensorMock = new Mock<ISensor>();
        sensorMock.Setup(x => x.PopNextPressurePsiValue())
            .Returns(expected);

        var alarmMock = new Mock<ICheckable>();
        bool alarm = false;

        alarmMock.Setup(x => x.Check())
            .Callback(() =>
            {
                if (sensorMock.Object.PopNextPressurePsiValue() < 17 || sensorMock.Object.PopNextPressurePsiValue() < 21)
                {
                    alarm = true;
                }
            });

        alarmMock.Object.Check();

        alarmMock.Verify(x => x.Check());
        Assert.IsTrue(alarm);
    }

    [Test]
    [TestCase(17)]
    [TestCase(21)]
    [TestCase(35)]
    public void CheckIfAlarmIsOff(double expected)
    {
        var sensorMock = new Mock<ISensor>();
        sensorMock.Setup(x => x.PopNextPressurePsiValue())
            .Returns(expected);

        var alarmMock = new Mock<ICheckable>();
        bool alarm = false;

        alarmMock.Setup(x => x.Check())
            .Callback(() =>
            {
                if (sensorMock.Object.PopNextPressurePsiValue() >= 17 || sensorMock.Object.PopNextPressurePsiValue() >= 21)
                {
                    alarm = true;
                }
            });

        alarmMock.Object.Check();

        alarmMock.Verify(x => x.Check());
        Assert.IsTrue(alarm);
    }
}
