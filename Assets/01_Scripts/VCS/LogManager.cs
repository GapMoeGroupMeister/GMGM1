using System;
using UnityEngine;

public class LogManager : MonoSingleton<LogManager>
{
    private float _playTime;
    public PlayDataLog playDataLog;

    [SerializeField] private bool isPlayTimeCount;

    private void Update()
    {
        if (isPlayTimeCount)
        {
            _playTime += Time.deltaTime;
        }
    }

    public void Pause()
    {
        isPlayTimeCount = false;
    }

    public void Resume()
    {
        isPlayTimeCount = true;
    }

    public void AddPlayLog(int killAmount)
    {
        playDataLog.playDataLog.Add(new PlayData(killAmount, _playTime));
        DBManager.SavePlayLog(playDataLog);
    }
}