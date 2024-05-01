using System.Collections;
using UnityEditor.AnimatedValues;
using UnityEngine;

//�߻� Ŭ����
public abstract class Gun : MonoBehaviour
{
    
    public bool IsCoolTime =>  _currentTime >= fireDelay;
    public bool reloadCheck = true;//������ üũ
    public bool isContinueFire;
    public bool _isReloading = false;
    public int damage = 0;//������
    public int maxBulletCount = 0;//��ź��
    public int currentBulletCount = 0;
    public float fireDelay;//���� �ӵ�
    public float reloadTime;//������ �ð�
    public float bulletSpeed;//�Ѿ� ���ǵ�
    public float destroyRange;//�����Ÿ�
    public float _currentTime = 0;
    public GunSO gunSO;
    public Bullet bulletPrefab;//�Ѿ� ������
    public Transform gunTip;//�ѱ� ��ġ
    public PlayerController _player;
    public Vector2 _mousePos;//���콺 ��ġ
    public abstract void Fire(Vector2 direction);
    
    protected virtual void Awake()
    {
        gunTip = transform.Find("GunTip");//�ѱ���ġ �޾ƿ�
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
        print("������");
        reloadCheck = false;
        yield return new WaitForSeconds(reloadTime); //reloadTime��ŭ ��ٷȴٰ� �ؿ� �ڵ带 ����
        reloadCheck = true;
        _isReloading = false;
        print("���� ����");
        currentBulletCount = maxBulletCount;
        GameManager.Instance.playerController.OnShootEvent?.Invoke(currentBulletCount, maxBulletCount);

    }
}
