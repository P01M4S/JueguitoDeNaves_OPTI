using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 4f;

    private float timer;
    private Vector3 direction;
    private ObjectPool pool;

    // Se llama cuando la bala sale del pool
    public void Init(ObjectPool poolReference, Vector3 dir)
    {
        pool = poolReference;
        direction = dir.normalized;
        timer = 0f;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            ReturnToPool();
        }

        // Si quieres que desaparezca al salir de cámara
        if (!IsVisibleFrom(Camera.main))
        {
            ReturnToPool();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí puedes llamar a un sistema de vida
            // other.GetComponent<PlayerHealth>()?.TakeDamage(1);

            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        if (pool != null)
        {
            pool.ReturnObject(gameObject);
        }
    }

    bool IsVisibleFrom(Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(
            planes,
            GetComponent<Collider>().bounds
        );
    }
}