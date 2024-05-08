using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TimerText;
    public float _currentTime = 0;
    
    [SerializeField] private bool isPlayTimeCount;

    private void Update()
    {
        if (isPlayTimeCount)
        {
            _currentTime += Time.deltaTime;
            Refresh();
        }
    }

    public void Pause()
    {
        isPlayTimeCount = false;
    }

    public void Resume()
    {
        isPlayTimeCount = true;
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