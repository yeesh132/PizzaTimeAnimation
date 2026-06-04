using UnityEngine;

public class SimpleWheelSpin : MonoBehaviour
{
    public float speed = 200f; // degrees per second

    void Update()
    {
        transform.Rotate(-speed * Time.deltaTime, 0f, 0f);
    }
}