using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTable", menuName = "SO/EnemyTable")]
public class EnemyTable : ScriptableObject
{
    private static EnemyTable _instance;

    public static EnemyTable Instance
    {
        get
        {
            if (_instance == null)            
                _instance = Resources.Load<EnemyTable>("Enemy/EnemyTable");

            return _instance;
        }
    }    

    public List<EnemyTableData> datas;

    public EnemyTableData Find(int code)
    {
        return datas.Find(x => x.Code == code);
    }
  
}