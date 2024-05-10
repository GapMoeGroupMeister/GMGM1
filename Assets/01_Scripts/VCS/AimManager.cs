using UnityEngine;

public class AimManager : MonoBehaviour
{
    [SerializeField] private Transform _aimMarkTrm;
    [SerializeField] private Transform _reloadMarkTrm;
    
    
    private Vector2 _mousePos;
    

    private void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _aimMarkTrm.position = _mousePos;
        
    }
}
