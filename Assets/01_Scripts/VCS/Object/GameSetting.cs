public class GameSetting
{
    public float soundLevel_Master;
    public float soundLevel_BGM;
    public float soundLevel_SFX;

    public GameSetting()
    {
        soundLevel_Master = 0;
        soundLevel_BGM = 0;
        soundLevel_SFX = 0;
        
    }

    public GameSetting(float master, float BGM, float SFX)
    {
        soundLevel_Master = master;
        soundLevel_BGM = BGM;
        soundLevel_SFX = SFX;
        

    }
    
}