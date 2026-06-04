using UnityEngine;

public class CarMover : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float speed = 5f;
    public bool localSpace = true;

    void Update()
    {
        Vector3 moveDir = localSpace
            ? transform.TransformDirection(direction.normalized)
            : direction.normalized;

        transform.position += moveDir * speed * Time.deltaTime;
    }
}