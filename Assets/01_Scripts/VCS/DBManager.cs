using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayDataLog
{
    public List<PlayData> playDataLog = new List<PlayData>();
}

public class DBManager
{
    private static string LOCALPATH = Application.dataPath+"/SaveData";
    
    
    public static GameSetting GetGameSetting()
    {
        string path = Path.Combine(LOCALPATH, "gameSetting.json");
        if (!Directory.Exists(LOCALPATH))
        {
            Debug.Log("폴더가 존재하지 않습니다.");
            Debug.Log("폴더를 생성합니다.");
            Directory.CreateDirectory(LOCALPATH);
        }
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            return JsonUtility.FromJson<GameSetting>(data);
        }

        GameSetting newSetting = new GameSetting();
        SaveGameSetting(newSetting);
        return newSetting;
    }

    public static void SaveGameSetting(GameSetting gameSetting)
    {
        if (!Directory.Exists(LOCALPATH))
        {
            Debug.Log("폴더가 존재하지 않습니다.");
            Debug.Log("폴더를 생성합니다.");
            Directory.CreateDirectory(LOCALPATH);
        }
        string json = JsonUtility.ToJson(gameSetting);
        string path = Path.Combine(LOCALPATH, "gameSetting.json");
        File.WriteAllText(path, json);

    }

    public static PlayDataLog GetPlayLog()
    {
        if (!Directory.Exists(LOCALPATH))
        {
            Debug.Log("폴더가 존재하지 않습니다.");
            Debug.Log("폴더를 생성합니다.");
            Directory.CreateDirectory(LOCALPATH);
        }
        string path = Path.Combine(LOCALPATH, "playData.json");
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayDataLog>(data);
        }

        PlayDataLog newLog = new PlayDataLog();
        SavePlayLog(newLog);
        return newLog;
    }

    public static void SavePlayLog(PlayDataLog log)
    {
        if (!Directory.Exists(LOCALPATH))
        {
            Debug.Log("폴더가 존재하지 않습니다.");
            Debug.Log("폴더를 생성합니다.");
            Directory.CreateDirectory(LOCALPATH);
        }
        string json = JsonUtility.ToJson(log);
        string path = Path.Combine(LOCALPATH, "playData.json");
        File.WriteAllText(path, json);

    }
    
}