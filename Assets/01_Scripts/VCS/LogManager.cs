using System;
using UnityEngine;

public class LogManager : MonoSingleton<LogManager>
{
    public PlayDataLog playDataLog;

    private void Awake()
    {
        playDataLog = DBManager.GetPlayLog();
        
    }

    public void AddPlayLog(int killAmount, float playTime)
    {
        print("플레이 로그저장");
        playDataLog.playDataLog.Add(new PlayData(killAmount, playTime));
        DBManager.SavePlayLog(playDataLog);
    }
}