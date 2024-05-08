public class PlayData
{
    public string playTimeLog;
    public int killAmount;
    public float playTime;

    public PlayData(int killAmount, float playTime)
    {
        playTimeLog = System.DateTime.Now.ToString("u");
        this.killAmount = killAmount;
        this.playTime = playTime;
        
    }
}