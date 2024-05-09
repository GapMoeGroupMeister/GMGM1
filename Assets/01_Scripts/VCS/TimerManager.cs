using System.Collections;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TimerText;
    public float _currentTime = 0;
    
    [SerializeField] private bool _isPlayTimeCount;
    [SerializeField] private float _startOffsetTime = 2f;


    private void Start()
    {
        StartCoroutine(TimerStartCoroutine());
    }

    private IEnumerator TimerStartCoroutine()
    {
        yield return new WaitForSeconds(_startOffsetTime);
        _isPlayTimeCount = true;
    }
    
    private void Update()
    {
        if (_isPlayTimeCount)
        {
            _currentTime += Time.deltaTime;
            Refresh();
        }
    }

    public void Pause()
    {
        _isPlayTimeCount = false;
    }

    public void Resume()
    {
        _isPlayTimeCount = true;
    }

    private void Refresh()
    {
        int ms = (int)(_currentTime * 100);
        int s = ms / 100;
        ms %= 100;

        int m = s / 60;
        s %= 60;
        _TimerText.text = $"{FillBlank(m,2)}:{FillBlank(s, 2)}.{ms}";
    }

    private string FillBlank(int num, int blank)
    {

        string result = "";
        int length = num.ToString().Length;
        for (int i = 0; i < blank-length; i++)
        {
            result += '0';
        }

        return $"{result}{num.ToString()}";
    }
}