using UnityEngine;

public class AimManager : MonoBehaviour
{
    [SerializeField] private Transform _aimMarkTrm;
    [SerializeField] private Transform _reloadMarkTrm;
    private PlayerWeaponManager gun;
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        gun = GameObject.Find("Player").GetComponent<PlayerWeaponManager>();//¿Ã∫Œ∫–
        _spriteRenderer = _aimMarkTrm.GetComponent<SpriteRenderer>();
    }



    private Vector2 _mousePos;


    private void Update()
    {

        
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _aimMarkTrm.position = _mousePos;
        if (!gun._gun.reloadCheck)
        {
            _spriteRenderer.color = Color.gray;
        }
        else
        {
            _spriteRenderer.color = Color.red;
        }

    }
}
