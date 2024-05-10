using UnityEngine;

public class LogUIManager : MonoBehaviour
{
    [SerializeField] private LogUI _logUIPrefab;
    [SerializeField] private Transform _contentTrm;
    [SerializeField] private PlayDataLog _log;

    private void Awake()
    {
        _log = DBManager.GetPlayLog();
        RefreshLog();
    }

    private void RefreshLog()
    {
        foreach (Transform child in _contentTrm)
        {
            Destroy(child.gameObject);
        }

        for (int i = _log.playDataLog.Count-1; i >= 0; i--)
        {
            LogUI log = Instantiate(_logUIPrefab, _contentTrm);
            log.SetLog(_log.playDataLog[i]);
        }

        // foreach (PlayData data in _log.playDataLog)
        // {
        //    
        // }
    }
}