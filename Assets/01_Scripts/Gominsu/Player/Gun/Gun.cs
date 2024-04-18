using System.Collections;
using UnityEditor.AnimatedValues;
using UnityEngine;

//추상 클래스
public abstract class Gun : MonoBehaviour
{
    
    public int damage = 0;//데미지

    public bool reloadCheck = true;//재장전 체크

    public int maxBulletCount = 0;//총탄수
    
    public int currentBulletCount = 0;
    public bool isContinueFire;
    
    public float fireDelay;//연사 속도

    public float reloadTime;//재장전 시간

    public float bulletSpeed;//총알 스피드

    public float destroyRange;//사정거리
    
    public bool IsCoolTime =>  _currentTime >= fireDelay;

    public GunSO gunSO;

    public Bullet bulletPrefab;//총얼 프리펩
    public Transform gunTip;//총구 위치
    
    
    private Vector2 _mousePos;//마우스 위치
    private PlayerController _player;
    private bool _isReloading;

    
    public abstract void Fire(Vector2 direction);
    private float _currentTime = 0;
    

    protected virtual void Awake()
    {
        gunTip = transform.Find("GunTip");//총구의치 받아옴
        fireDelay = gunSO.fireDelay;
        damage = gunSO.damage;
        maxBulletCount = gunSO.maxBulletCount;
        reloadTime = gunSO.reloadTime;
        isContinueFire = gunSO.isContinueFire;
        bulletSpeed = gunSO.bulletSpeed;
        destroyRange = gunSO.destroyRange;
        bulletPrefab = gunSO.bulletPrefab;
        currentBulletCount = maxBulletCount;

        
    }

    protected virtual void Start()
    {
        _player = GameManager.Instance.playerController;
    }

    protected virtual void Update()
    {
        _currentTime += Time.deltaTime;
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//마우스 위치를 월드 좌표로 변환
        Rotate();

        GunInput();
        GunRender();
    }

    private void GunRender()
    {
        if (_player.transform.position.x > _mousePos.x)   
        {
            transform.position = new Vector3(_player.transform.position.x + -0.7f, _player.transform.position.y, 0);
        }
        else
        {
            transform.position = new Vector3(_player.transform.position.x + 0.7f, _player.transform.position.y, 0);
        }
    }
    

    private void GunInput()
    {
        if (currentBulletCount <= 0 && !_isReloading)
        {
            _isReloading = true;
            Reload();
        }
        if (Input.GetMouseButtonDown(1))//우클릭
        {
            //knife.Slash();
        }
        
        if (!IsCoolTime)
        {
             return;      
        }
        if (isContinueFire)
        {
            if (Input.GetMouseButton(0))//좌클릭 홀드
            {
                _currentTime = 0;
               
                FireHandler();
                
            }
        }
        else
        {
            
            if (Input.GetMouseButtonDown(0))//좌클릭
            {
                _currentTime = 0;
               
                FireHandler();
            }
        }
        
    }
    
    protected virtual void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }
    
    protected void Rotate()
    {
        Vector2 dir = (_mousePos - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    protected void FireHandler()
    {
        Vector2 dir = _mousePos - (Vector2)transform.position;
        if (reloadCheck == false) return;
        currentBulletCount--;
        GameManager.Instance.playerController.OnShootEvent?.Invoke(currentBulletCount, maxBulletCount);
        
        Fire(dir.normalized);
    }

   

    
    protected virtual IEnumerator ReloadCoroutine()
    {
        print("장전중");
        reloadCheck = false;
        yield return new WaitForSeconds(reloadTime); //reloadTime만큼 기다렸다가 밑에 코드를 실행
        reloadCheck = true;
        _isReloading = false;
        print("장전 끝남");
        currentBulletCount = maxBulletCount;
        GameManager.Instance.playerController.OnShootEvent?.Invoke(currentBulletCount, maxBulletCount);

    }
}
