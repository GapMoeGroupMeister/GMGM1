using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public PlayerController playerController { get; private set; }
    public TimerManager timerManager { get; private set; }


    [SerializeField] private TextMeshProUGUI _killCountText;
    public Action<int, int> OnGunRefreshEvent;
    public int killCount = 0;
    [SerializeField] private int _goalKillAmount = 100;
    private bool _isGameOver;
    [SerializeField] private GameObject _gameClearUI;
    [SerializeField] private TMP_Text _currentKillCount;
    [SerializeField] private TMP_Text _clearTime;

    // 엑시트 탈때 이거 체크하고
    // true일 시 엔딩
    public bool IsGameClear => killCount >= _goalKillAmount && !_isGameOver;


    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        timerManager = FindObjectOfType<TimerManager>();
    }

    private void Start()
    {
        RefreshSkillCount();
        _gameClearUI.SetActive(false);
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
        timerManager.Pause();
        LogManager.Instance.AddPlayLog(killCount, timerManager._currentTime);
        Time.timeScale = 0;
    }

    public void GameClear()
    {
        GameOver();
        _gameClearUI.SetActive(true);
        _currentKillCount.text = $"킬 : {killCount}";
        _clearTime.text = $"클리어 시간 : {Mathf.Floor(timerManager._currentTime * 100f) / 100f}초";

    }

    public void Quit()
    {
        Application.Quit();
    }
}