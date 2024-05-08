using System;
using UnityEngine;

public class LogManager : MonoSingleton<LogManager>
{
    public PlayDataLog playDataLog;

    private void Awake()
    {
        playDataLog = DBManager.GetPlayLog();
        if (playDataLog == null)
            playDataLog = new PlayDataLog();
    }

    public void AddPlayLog(int killAmount, float playTime)
    {
        playDataLog.playDataLog.Add(new PlayData(killAmount, playTime));
        DBManager.SavePlayLog(playDataLog);
    }
}