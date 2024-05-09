using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameControlManager : MonoBehaviour
{
    [SerializeField]
    private bool _isOnMenuUI;
    public UnityEvent OnMenuShowEvent;
    public UnityEvent OnMenuOffEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnMenu_();
        }
    }

    public void OnMenu_()
    {
       
        _isOnMenuUI = true;
        OnMenuShowEvent?.Invoke();
        GameManager.Instance.Pause();
        GameManager.Instance.SetPlayerControlOff();
        
        // if (_isOnMenuUI)
        // {
        //     _isOnMenuUI = false;
        //     OnMenuOffEvent?.Invoke();  
        //     GameManager.Instance.Resume();
        //     GameManager.Instance.SetPlayerControlOn();
        // }
        // else
        // {
        // }
    }

    public void OffMenu()
    {
        _isOnMenuUI = false;
        OnMenuOffEvent?.Invoke();  
        GameManager.Instance.Resume();
        GameManager.Instance.SetPlayerControlOn();
    }

    
    public void Quit()
    {
        SceneManager.LoadScene("StartScene");
    }
}
