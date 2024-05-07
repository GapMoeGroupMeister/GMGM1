using Unity.VisualScripting;

public class PlayData
{
    public int playTimeLog;
    public int killAmount;
    public float playTime;

    public PlayData(int killAmount, float playTime)
    {
        this.killAmount = killAmount;
        this.playTime = playTime;
    }
}