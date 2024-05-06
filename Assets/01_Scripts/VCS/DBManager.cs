using System.IO;
using UnityEngine;

public class DBManager
{
    private const string LOCALPATH = "/SaveData/";
    
    
    public static GameSetting GetGameSetting()
    {
        string path = Path.Combine(Application.dataPath + LOCALPATH, "gameSetting.json");
        string data = File.ReadAllText(path);
        return JsonUtility.FromJson<GameSetting>(data);
    }

    public static void SaveGameSetting(GameSetting gameSetting)
    {
        string json = JsonUtility.ToJson(gameSetting);
        string path = Path.Combine(Application.dataPath + LOCALPATH, "gameSetting.json");
        File.WriteAllText(path, json);

    }
    
}