using System;

public class GameManager : MonoSingleton<GameManager>
{
    public PlayerController playerController { get; private set; }
    public TimerManager timerManager { get; private set; }
    
    
    public Action<int, int> OnGunRefreshEvent;
    public int killCount = 0;
    
    
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        timerManager = FindObjectOfType<TimerManager>();
    }

    private void OnDisable()
    {
        OnGunRefreshEvent = null;
        
    }

    public void RefreshBullet(int current, int max)
    {
        OnGunRefreshEvent?.Invoke(current, max);
    }

    public void GameOver()
    {
        LogManager.Instance.AddPlayLog(killCount, timerManager._currentTime);
    }
}