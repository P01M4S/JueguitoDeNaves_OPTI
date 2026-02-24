using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 15, -5);

    void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}