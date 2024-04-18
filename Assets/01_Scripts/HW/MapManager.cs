using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoSingleton<MapManager>
{
    private StageSO _stageSO;

    private GameObject _currentStagePrefab;

    private int _currentStageIndex = 0;

    public void NextStage()
    {
        Destroy(_currentStagePrefab);
        _currentStageIndex++;
        _currentStagePrefab = Instantiate(_stageSO.stagePrefab[_currentStageIndex]);
    }
}
