using System;
using UnityEngine;

public class LogManager : MonoSingleton<LogManager>
{
    public PlayDataLog playDataLog;

    

    public void AddPlayLog(int killAmount, float playTime)
    {
        playDataLog.playDataLog.Add(new PlayData(killAmount, playTime));
        DBManager.SavePlayLog(playDataLog);
    }
}