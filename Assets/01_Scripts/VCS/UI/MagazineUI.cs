using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagazineUI : MonoBehaviour
{
    [SerializeField] private bool _isPlaying;
    private Tweener currentTween;
    
    [Header("UI Object")]
    [SerializeField] private RectTransform _magazineTrm;
    [SerializeField] private ParticleSystem _shellParticle;
    [SerializeField] private TextMeshProUGUI _textLeftBullets;
    [SerializeField] private Image _gaugeHandle;
    [Header("Shaking Setting")] 
    [SerializeField] private float _shakePower = 30;
    [SerializeField] private int _vibrato = 20;

    [Header("Text Setting")] 
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _alertColor;

    // 나중에 플레이어쪽 Action<int, int>하나 만들어서 구독 ㄱ

    public event Action<int, int> shootEvent;


    

    [ContextMenu("Debug_shoot")]
    public void Shoot(int currentBullet, int maxBullets)
    {
        Shake(_shakePower, _vibrato, 0.5f);
        Refresh(currentBullet, maxBullets);
        
        _shellParticle.Play();
    }

    private void Refresh(int currentBullets, int maxBullets)
    {
        if (currentBullets <= 0)
            _textLeftBullets.color = _alertColor;
        else
            _textLeftBullets.color = _defaultColor;

        _gaugeHandle.fillAmount = currentBullets / (float)maxBullets;
        _textLeftBullets.text = $"{currentBullets}/{maxBullets}";
        
    }

    public void Shake(float power, int vibrato, float duration)
    {
        currentTween = _magazineTrm.DOShakeAnchorPos(duration, power, vibrato);
        _isPlaying = true;
    }

}
