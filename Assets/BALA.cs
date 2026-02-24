using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 3f;

    private float timer;
    private Vector3 direction;
    private ObjectPool pool;

    public void Init(ObjectPool poolReference)
    {
        pool = poolReference;
        timer = 0;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            pool.ReturnObject(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        pool.ReturnObject(gameObject);
    }
}