using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClear : MonoBehaviour
{
    [SerializeField] private GameObject _gameClearUI;
    [SerializeField] private TMP_Text _currentKillCount;
    [SerializeField] private TMP_Text _clearTime;

    GameOver _gameOver;

    private void Awake()
    {
        _gameClearUI.SetActive(false);
        _gameOver = FindObjectOfType<GameOver>();
    }

    public void GameClearUI()
    {
        _gameClearUI.SetActive(true);
        _currentKillCount.text = $"킬 : {GameManager.Instance.killCount}";
        _clearTime.text = $"클리어 시간 : {Mathf.Floor(GameManager.Instance.timerManager._currentTime * 100f) / 100f}초";
        _gameOver.gameOverUI.SetActive(false);
    }

}
