public class EventLogger : Logger
{
    public override void Handle(LogType type, string message)
    {
        switch (type)
        {
            case LogType.ATTACK:
                break;
            case LogType.MAGIC:
                break;
            case LogType.TARGET:
                break;
            case LogType.ERROR:
                break;
            case LogType.EVENT:
                break;
        }

        this.PassToSuccessor(type, message);
    }
}
