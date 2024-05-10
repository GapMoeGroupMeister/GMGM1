using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    [SerializeField] private TMP_Text _currentKillUI;
    [SerializeField] private TMP_Text _currentTimeUI;

    public GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }
    public void GameOverUI()
    {
        gameOverUI.SetActive(true);
        _currentKillUI.text = $"ų : {GameManager.Instance.killCount}";
        _currentTimeUI.text = $"�÷��� �ð� : {Mathf.Floor(GameManager.Instance.timerManager._currentTime * 100f) / 100f}��";
            
    }

}
