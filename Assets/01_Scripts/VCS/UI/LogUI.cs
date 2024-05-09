using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _killAmountText;
    [SerializeField] private TextMeshProUGUI _playTimeText;
    [SerializeField] private TextMeshProUGUI _playRecordedText;

    [SerializeField]
    private PlayData _playData;
    
    public void SetLog(PlayData data)
    {
        _playData = data;
        if(_playData.killAmount >= 100) _killAmountText.color = Color.yellow;
        _killAmountText.text = _playData.killAmount.ToString();
        _playTimeText.text = GetTimerString();
        _playRecordedText.text = _playData.playTimeLog;
    }
    
    private string GetTimerString()
    {
        int ms = (int)(_playData.playTime * 100);
        int s = ms / 100;
        ms %= 100;
        int m = s / 60;
        s %= 60;
        return $"{FillBlank(m,2)}:{FillBlank(s, 2)}.{FillBlank(ms, 2)}";
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
