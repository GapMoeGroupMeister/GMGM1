using System.Collections;
using UnityEditor.AnimatedValues;
using UnityEngine;

//추상 클래스
public abstract class Gun : MonoBehaviour
{
    
    public bool IsCoolTime =>  _currentTime >= fireDelay;
    public bool reloadCheck = true;//재장전 체크
    public bool isContinueFire;
    public bool _isReloading = false;
    public int damage = 0;//데미지
    public int maxBulletCount = 0;//총탄수
    public int currentBulletCount = 0;
    public float fireDelay;//연사 속도
    public float reloadTime;//재장전 시간
    public float bulletSpeed;//총알 스피드
    public float destroyRange;//사정거리
    public float _currentTime = 0;
    public GunSO gunSO;
    public Bullet bulletPrefab;//총얼 프리펩
    public Transform gunTip;//총구 위치
    public PlayerController _player;
    public Vector2 _mousePos;//마우스 위치
    public abstract void Fire(Vector2 direction);
    
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
    
    public virtual void Reload()
    {
        StartCoroutine(ReloadCoroutine());
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
