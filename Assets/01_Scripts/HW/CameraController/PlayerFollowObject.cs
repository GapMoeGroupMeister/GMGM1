using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowObject : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform _playerTrm;

    [Header("Flip Rotation Settings")]
    [SerializeField] private float _flippingTime = 0.5f;

    private Coroutine _turnCoroutine;

    /*private Player _player;

    private void Awake()
    {
        _player = _playerTrm.GetComponent<Player>();
        _player.OnFlip += HandleFlipEvent;
    }

    private void OnDestroy()
    {
        if (_player == null) return;
        _player.OnFlip -= HandleFlipEvent;
    }
*/
    private void Update()
    {
        transform.position = _playerTrm.position;
    }

    private void HandleFlipEvent(int facingDirection)
    {
        if (_turnCoroutine != null) 
            StopCoroutine(_turnCoroutine);
        _turnCoroutine = StartCoroutine(FlipYLerp(facingDirection));
    }

    IEnumerator FlipYLerp(int facingDirection)
    {
        float startRotation = transform.localEulerAngles.y;
        float endRotationAmount = facingDirection == 1 ? 0f : 180f;
        float yRotation = 0;

        float elapsedTime = 0f;
        float totalTime = _flippingTime * Mathf.Abs(endRotationAmount - startRotation) / 180f;
        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            yRotation = Mathf.Lerp(startRotation, endRotationAmount, elapsedTime / totalTime);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
            yield return null;
        }
    }

    private void OnValidate()
    {
        if (_playerTrm != null) transform.position = _playerTrm.position;
    }
}
