using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float speed = 10f;
    public ObjectPool bulletPool;
    public Transform firePoint;
    private Transform _player;

    void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * speed * Time.deltaTime);
    }

    void Shoot()
{
    if (Input.GetMouseButtonDown(0)) // Click izquierdo
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;

        Bullet b = bullet.GetComponent<Bullet>();
        b.SetDirection(Vector3.forward); // En top-down forward suele ser hacia arriba visual
        b.Init(bulletPool);
    }
}

}