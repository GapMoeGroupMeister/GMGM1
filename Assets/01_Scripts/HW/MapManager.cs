using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapManager : MonoSingleton<MapManager>
{
    [SerializeField]
    private StageSO _stageSO;

    private GameObject _currentStagePrefab;

    public event Action OnStageChange;

    public Transform[] GetEnemyPositions()
    {
        return _currentStagePrefab.transform.Find("EnemyPos").GetComponentsInChildren<Transform>();
    }

    public Transform NextStage()
    {
        OnStageChange?.Invoke();
        Destroy(_currentStagePrefab);
        int rand = Random.Range(0, _stageSO.stagePrefabs.Count);
        _currentStagePrefab = Instantiate(_stageSO.stagePrefabs[rand]);
        return _currentStagePrefab.transform;
    }
}
