using System;
using System.Collections;
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
    [SerializeField] private GameObject _lightObject;
    [SerializeField] private Image _gridImage;
    
    private Material _gridMaterial;
    private int _gridPropertyHash;

    [SerializeField] private Image _gaugeHandle;
    [Header("Shaking Setting")] 
    [SerializeField] private float _shakePower = 30;
    [SerializeField] private int _vibrato = 20;
    [SerializeField] private float _shakeDuration = 0.3f;
 
    [Header("Text Setting")] 
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _alertColor;

    
    [Header("Debug Setting")] 
    [SerializeField] private int currentBullet = 10;
    [SerializeField] private int maxBullet = 10;
    [SerializeField] private float _shootTerm = 0.3f;
    private float currentTime = 0;

    // 나중에 플레이어쪽 Action<int, int>하나 만들어서 구독 ㄱ
    // 지금은 이쪽에 Action을 달아놓음
    public event Action<int, int> shootEvent;

    private void Awake()
    {
    }

    private void Start()
    {
        _gridMaterial = _gridImage.material;
        shootEvent += Shoot;
    }
    private void OnDisable()
    {
        shootEvent -= shootEvent;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentBullet = maxBullet;
            Refresh(currentBullet, maxBullet);
        }

        currentTime += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            
            if (currentTime >= _shootTerm)
            {
                
                currentTime = 0;
                if (currentBullet <= 0)
                {
                    Refresh(currentBullet, maxBullet);
                    currentTime = -1;
                    Shake(_shakePower, _vibrato, _shakeDuration);
                    return;
                }
                currentBullet--;

                shootEvent?.Invoke(currentBullet, maxBullet);
            }
        }
    }

    [ContextMenu("Debug_shoot")]
    public void Shoot(int currentBullet, int maxBullets)
    {
        Shake(_shakePower, _vibrato, _shakeDuration);
        StartCoroutine(ShootCoroutine());
        Refresh(currentBullet, maxBullets);
        
        _shellParticle.Play();
    }

    private IEnumerator ShootCoroutine()
    {
        _lightObject.SetActive(true);
        yield return new WaitForSeconds(_shakeDuration * 0.7f);
        _lightObject.SetActive(false);
    }

    private void Refresh(int currentBullets, int maxBullets)
    {
        _gridMaterial.SetFloat("_GridWidth", maxBullets);
        if (currentBullets <= 0)
            _textLeftBullets.color = _alertColor;
        else
            _textLeftBullets.color = _defaultColor;

        _gaugeHandle.fillAmount = currentBullets / (float)maxBullets;
        _textLeftBullets.text = $"{currentBullets}/{maxBullets}";
        
    }

    public void Shake(float power, int vibrato, float duration)
    {
        if (currentTween != null && currentTween.active) return;
        currentTween = _magazineTrm.DOShakeAnchorPos(duration, power, vibrato);
        _isPlaying = true;
        
    }

}
