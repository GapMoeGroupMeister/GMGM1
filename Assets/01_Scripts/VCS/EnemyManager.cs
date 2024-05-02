using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [SerializeField] 
    private List<Enemy> _enemyList;
    [SerializeField]
    private List<Enemy> _enemyPrefabBase;

    public int AliveEnemy => _enemyList.Count;

    public void GenerateEnemy(Transform[] SpawnPosTrms)
    {
        foreach (Enemy e in _enemyList)
        {
            Destroy(e.gameObject);
        }
        _enemyList = new List<Enemy>();
        foreach (Transform trm in SpawnPosTrms)
        {
            Enemy randomEnemy = _enemyPrefabBase[Random.Range(0, _enemyPrefabBase.Count)];
            Instantiate(randomEnemy, trm.position, Quaternion.identity);
            _enemyList.Add(randomEnemy);
            
        }
    }
    
}
