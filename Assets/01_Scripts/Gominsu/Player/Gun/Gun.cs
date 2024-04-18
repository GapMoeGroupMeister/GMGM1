using System.Collections;
using UnityEditor.AnimatedValues;
using UnityEngine;

//�߻� Ŭ����
public abstract class Gun : MonoBehaviour
{
    
    public int damage = 0;//������

    public bool reloadCheck = true;//������ üũ

    public int maxBulletCount = 0;//��ź��
    
    public int currentBulletCount = 0;
    public bool isContinueFire;
    
    public float fireDelay;//���� �ӵ�

    public float reloadTime;//������ �ð�

    public float bulletSpeed;//�Ѿ� ���ǵ�

    public float destroyRange;//�����Ÿ�
    
    public bool IsCoolTime =>  _currentTime >= fireDelay;

    public GunSO gunSO;

    public Bullet bulletPrefab;//�Ѿ� ������
    public Transform gunTip;//�ѱ� ��ġ
    
    
    private Vector2 _mousePos;//���콺 ��ġ
    private PlayerController _player;
    private bool _isReloading;

    
    public abstract void Fire(Vector2 direction);
    private float _currentTime = 0;
    

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

    protected virtual void Update()
    {
        _currentTime += Time.deltaTime;
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//���콺 ��ġ�� ���� ��ǥ�� ��ȯ
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
        if (Input.GetMouseButtonDown(1))//��Ŭ��
        {
            //knife.Slash();
        }
        
        if (!IsCoolTime)
        {
             return;      
        }
        if (isContinueFire)
        {
            if (Input.GetMouseButton(0))//��Ŭ�� Ȧ��
            {
                _currentTime = 0;
               
                FireHandler();
                
            }
        }
        else
        {
            
            if (Input.GetMouseButtonDown(0))//��Ŭ��
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
