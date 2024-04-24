public class GameManager : MonoSingleton<GameManager>
{
    public PlayerController playerController { get; private set; }

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
}