using System;

public class GameManager : MonoSingleton<GameManager>
{
    public PlayerController playerController { get; private set; }

    public Action<int, int> OnGunRefreshEvent;


    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();

    }

    public void RefreshBullet(int current, int max)
    {
        OnGunRefreshEvent?.Invoke(current, max);
    }
}