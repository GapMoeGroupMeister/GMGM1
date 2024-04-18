public class TimeManager
{
    public static float TimeScale { get; private set; } = 1;

    public static void SetTimeStop()
    {
        TimeScale = 0;
    }

    public static void SetTimePlay()
    {
        TimeScale = 1;
    }

}