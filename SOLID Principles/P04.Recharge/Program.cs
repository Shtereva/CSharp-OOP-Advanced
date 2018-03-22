namespace P04.Recharge
{
    public class Program
    {
        public static void Main()
        {
            var robot = new Robot("1", 50);
            robot.Work(60);
            robot.Recharge();

            var employee = new Employee("2");
            employee.Work(6);
            employee.Sleep();
        }
    }
}
