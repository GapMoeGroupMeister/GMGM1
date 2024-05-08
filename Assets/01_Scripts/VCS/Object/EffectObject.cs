using System;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particles;
    
    public float playTime = 2;
    private float _currentTime = 0;

    private void OnEnable()
    {
        SetDefault(5);
        Play();
    }

    private void Update()
    {
        LifeTime();
    }

    public virtual void Play()
    {
        for (int i = 0; i < _particles.Length; i++)
        {
            _particles[i].Play();
        }   
        
    }

    public void SetDefault(float playTime)
    {
        this.playTime = playTime;
        _currentTime = 0;
    }
    
    private void LifeTime()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= playTime)
        {
            Die();

        }
    }

    private void Die()
    {
        // 나중에 풀링으로 변경
        gameObject.SetActive(false);
        
    }
}