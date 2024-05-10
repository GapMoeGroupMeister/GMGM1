using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public PlayerController playerController { get; private set; }
    public TimerManager timerManager { get; private set; }


    [SerializeField] private TextMeshProUGUI _killCountText;
    public Action<int, int> OnGunRefreshEvent;
    public int killCount = 0;
    [SerializeField] private int _goalKillAmount = 100;
    private bool _isGameOver;
    private GameClear _gameClear;
    private GameOver GameOverUIManager;

    // 설정 UI가 켜지거나 하면 false가 됨
    public bool CanPlayerControl = true;


    // 엑시트 탈때 이거 체크하고
    // true일 시 엔딩
    public bool IsGameClear => killCount >= _goalKillAmount && !_isGameOver;


    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        timerManager = FindObjectOfType<TimerManager>();
        _gameClear = FindObjectOfType<GameClear>();
        GameOverUIManager = FindObjectOfType<GameOver>();
    }

    private void Start()
    {
        RefreshSkillCount();
        
    }

    private void OnDisable()
    {
        OnGunRefreshEvent = null;
        
    }

    public void RefreshBullet(int current, int max)
    {
        OnGunRefreshEvent?.Invoke(current, max);
    }

    public void AddKillCount()
    {
        if (_isGameOver) return;

        killCount++;
        RefreshSkillCount();
    }

    private void RefreshSkillCount()
    {
        _killCountText.text = $"처치 : {killCount}";

    }

    public void Pause()
    {
        timerManager.Pause();
    }

    public void Resume()
    {
        timerManager.Resume();
    }

    public void GameOver()
    {
        
        if (_isGameOver) return;
        _isGameOver = true;
        GameOverUIManager.GameOverUI();
        timerManager.Pause();
        LogManager.Instance.AddPlayLog(killCount, timerManager._currentTime);
        Time.timeScale = 0;
    }

    public void GameClear()
    {
        GameOver();
        _gameClear.GameClearUI();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetPlayerControlOff()
    {
        CanPlayerControl = false;
    }
    
    public void SetPlayerControlOn()
    {
        CanPlayerControl = true;
    }

    public void ExitInGame()
    {
        SceneManager.LoadScene("StartScene");
        
    }
}