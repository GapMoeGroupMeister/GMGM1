using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameControlManager : MonoBehaviour
{
    [SerializeField]
    private bool _isOnMenuUI;
    public UnityEvent OnMenuShowEvent;
    public UnityEvent OnMenuOffEvent;

    
    public void OnMenu()
    {
        if (_isOnMenuUI)
        {
            _isOnMenuUI = false;
            OnMenuOffEvent?.Invoke();  
            GameManager.Instance.Resume();
        }
        else
        {
            _isOnMenuUI = true;
            OnMenuShowEvent?.Invoke();
            GameManager.Instance.Pause();

        }
    }

    
    public void Quit()
    {
        SceneManager.LoadScene("StartScene");
    }
}
