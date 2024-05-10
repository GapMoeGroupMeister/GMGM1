using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MapManager : MonoSingleton<MapManager>
{
    [SerializeField]
    private StageSO _stageSO;
    [SerializeField]
    private Image _fadeImage;

    [SerializeField]
    private GameObject _currentStagePrefab;

    public event Action OnStageChange;

    public PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        NextStage();
    }

    public Transform[] GetEnemyPositions()
    {
        return _currentStagePrefab.transform.Find("EnemyPos").GetComponentsInChildren<Transform>();
    }

    public Transform NextStage()
    {
        _fadeImage.gameObject.SetActive(true);
        _fadeImage.color = Color.clear;
        _fadeImage.DOColor(Color.black, 1).OnComplete(() => {
            Destroy(_currentStagePrefab);
            int rand = Random.Range(0, _stageSO.stagePrefabs.Count);
            _currentStagePrefab = Instantiate(_stageSO.stagePrefabs[rand]);
            player.transform.position = _currentStagePrefab.transform.Find("SpawnPoint").position;
            _fadeImage.gameObject.SetActive(false);
            OnStageChange?.Invoke();
        });
        return _currentStagePrefab.transform;
    }
}
