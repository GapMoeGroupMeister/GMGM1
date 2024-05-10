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
        _currentKillCount.text = $"ų : {GameManager.Instance.killCount}";
        _clearTime.text = $"Ŭ���� �ð� : {Mathf.Floor(GameManager.Instance.timerManager._currentTime * 100f) / 100f}��";
        _gameOver.gameOverUI.SetActive(false);
    }

}
