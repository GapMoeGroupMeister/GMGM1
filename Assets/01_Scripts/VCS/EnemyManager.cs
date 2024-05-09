using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [SerializeField] 
    private List<Enemy> _enemyList = new List<Enemy>();
    [SerializeField]
    private List<Enemy> _enemyPrefabBase;
    [SerializeField] private TextMeshProUGUI _enemyAmountText;
    
    //public int AliveEnemy => _enemyList.Count;
    public int aliveEnemyCount = 0;

    private void Start()
    {
        MapManager.Instance.OnStageChange += GenerateEnemy;
    }

    private void OnDisable()
    {
        MapManager.Instance.OnStageChange -= GenerateEnemy;
    }

    public void GenerateEnemy()
    {
        foreach (Enemy e in _enemyList)
        {
            if (e == null) continue;
            Destroy(e.gameObject);
        }

        Transform[] SpawnPosTrms = MapManager.Instance.GetEnemyPositions();
        _enemyList = new List<Enemy>();
        foreach (Transform trm in SpawnPosTrms)
        {
            Enemy randomEnemy = _enemyPrefabBase[Random.Range(0, _enemyPrefabBase.Count)];
            Instantiate(randomEnemy, trm.position, Quaternion.identity);
            _enemyList.Add(randomEnemy);
            
        }

        aliveEnemyCount = _enemyList.Count;
        UpdateEnemyAmount();
    }

    private void UpdateEnemyAmount()
    {
        
        _enemyAmountText.text = $"<size=50>남은 적 : </size><color=red>{aliveEnemyCount}";
    }
    
    public void DeleteEnemy(Enemy enemy)
    {
        aliveEnemyCount--;
        _enemyList.Remove(enemy);
        UpdateEnemyAmount();
    }
    
}
