using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField] private List<CinemachineVirtualCamera> _virtualCamList;
    [SerializeField] private PlayerFollowObject _playerFollowObject;

    private Tween _panCameraTween;
    private Vector2 _startingTrackedObjectOffset;
    private Dictionary<PanDirection, Vector2> _panDictionary; 

    [Header("Lerf setting for jump and fall")]
    [SerializeField] private float _fallPanAmount = 0.2f;
    [SerializeField] private float _fallYPanTime = 0.5f; 
    public float fallSpeedYDampingThreshold = -15f; 

    public bool IsLerpingYDamping { get; private set; }
    public bool LerpedFromPlayerFall { get; set; } 

    private Tween _lerpYTween;
    private CinemachineFramingTransposer _framingTransposer;
    private CinemachineVirtualCamera _currentCam;
    private CinemachineConfiner2D _confiner;

    private float _defaultYPanAmount;

    private void Awake()
    {
        ChangeCamera(_virtualCamList[0]);
        _panDictionary = new Dictionary<PanDirection, Vector2>()
        {
            {PanDirection.Up, Vector2.up },
            {PanDirection.Down, Vector2.down},
            {PanDirection.Left, Vector2.left},
            {PanDirection.Right, Vector2.right},
        };
    }

    public void ChangeCamera(CinemachineVirtualCamera activeCam)
    {
        _virtualCamList.ForEach(x => x.Priority = 5);
        activeCam.Priority = 10;
        _currentCam = activeCam;
        _framingTransposer = _currentCam.GetCinemachineComponent<CinemachineFramingTransposer>();
        _defaultYPanAmount = _framingTransposer.m_YDamping;

        _confiner = _currentCam.GetComponent<CinemachineConfiner2D>();

        _startingTrackedObjectOffset = _framingTransposer.m_TrackedObjectOffset;
        _currentCam.Follow = _playerFollowObject.transform;
    }

    public void ChangeCameraBound(CompositeCollider2D confinerCollider)
    {
        _confiner.m_BoundingShape2D = confinerCollider;
    }

    public void LerpYDamping(bool isPlayerFall)
    {
        if (_lerpYTween != null && _lerpYTween.IsActive())
            _lerpYTween.Kill();

        float endDampingAmount = _defaultYPanAmount;
        if (isPlayerFall)
        {
            endDampingAmount = _fallPanAmount;
            LerpedFromPlayerFall = true;
        }

        IsLerpingYDamping = true;
        _lerpYTween = DOTween.To(() => _framingTransposer.m_YDamping, v => _framingTransposer.m_YDamping = v, endDampingAmount, _fallYPanTime).OnComplete(() => IsLerpingYDamping = false);
    }

    public void PanCameraOnContact(float panDistance, float panTime, PanDirection panDir, bool panToStartingPos)
    {
        Vector3 endPos = Vector3.zero;

        if(!panToStartingPos)
        {
            endPos = _panDictionary[panDir] * panDistance + _startingTrackedObjectOffset;
        }
        else
        {
            endPos = _startingTrackedObjectOffset;
        }

        if (_panCameraTween != null && _panCameraTween.IsActive())
            _panCameraTween.Kill();

        _panCameraTween = DOTween.To(() => _framingTransposer.m_TrackedObjectOffset, v => _framingTransposer.m_TrackedObjectOffset = v, endPos, panTime);
    }


    public void SwapCamera(CinemachineVirtualCamera camFromLeft, CinemachineVirtualCamera camFromRight, Vector2 exitDirection)
    {
        if(_currentCam == camFromLeft && exitDirection.x > 0)
        {
            ChangeCamera(camFromRight);
        }
        else if(_currentCam == camFromRight && exitDirection.x < 0)
        {
            ChangeCamera(camFromLeft);
        }
    }
}
