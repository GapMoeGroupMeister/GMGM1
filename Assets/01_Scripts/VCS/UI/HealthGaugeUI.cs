using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthGaugeUI : MonoBehaviour
{
    [SerializeField] private Image _gaugeFillHandle;

    private void Start()
    {
        // playerHp있는곳에 플레이어 체력변경시 작동하는
        // OnHealthChanged Action하나 만들어서 구독

        GameManager.Instance.playerController.OnHealthChangedEvent += Refresh;
    }

    private void OnDisable()
    {
        GameManager.Instance.playerController.OnHealthChangedEvent -= Refresh;
    }

    public void Refresh(int currentValue, int maxValue)
    {
        
        _gaugeFillHandle.fillAmount = currentValue / (float)maxValue;
    }

    
}