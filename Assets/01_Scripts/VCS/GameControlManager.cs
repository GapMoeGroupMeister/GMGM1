using UnityEngine;
using UnityEngine.Events;

public class GameControlManager : MonoBehaviour
{
    private bool _isOnMenuUI;
    public UnityEvent OnMenuShowEvent;
    public UnityEvent OnMenuOffEvent;

    
    public void OnMenu()
    {
        if (_isOnMenuUI)
        {
            _isOnMenuUI = false;
            OnMenuOffEvent?.Invoke();            
        }
        else
        {
            _isOnMenuUI = true;
            OnMenuShowEvent?.Invoke();

        }
    }
}
