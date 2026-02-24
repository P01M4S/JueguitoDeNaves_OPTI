using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public ObjectPool bulletPool;
    public Transform firePoint;

    private ObjectPool myPool;

     private Transform _player;

    void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    public void Init(ObjectPool poolReference)
    {
        myPool = poolReference;
        InvokeRepeating(nameof(Shoot), 1f, 2f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.z < -10f)
        {
            ReturnToPool();
        }
    }

    void Shoot()
{
    if (bulletPool == null) return;

    GameObject bullet = bulletPool.GetObject();
    bullet.transform.position = firePoint.position;

    Vector3 direction = (_player.position - firePoint.position).normalized;

    bullet.transform.rotation = Quaternion.LookRotation(direction);

    Bullet b = bullet.GetComponent<Bullet>();
    b.SetDirection(direction);
    b.Init(bulletPool);
}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        CancelInvoke();
        myPool.ReturnObject(gameObject);
    }
}