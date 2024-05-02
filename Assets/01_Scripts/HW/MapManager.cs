using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoSingleton<MapManager>
{
    [SerializeField]
    private StageSO _stageSO;

    private GameObject _currentStagePrefab;

    public Transform NextStage()
    {
        Destroy(_currentStagePrefab);
        int rand = Random.Range(0, _stageSO.stagePrefabs.Count);
        _currentStagePrefab = Instantiate(_stageSO.stagePrefabs[rand]);
        return _currentStagePrefab.transform;
    }
}
