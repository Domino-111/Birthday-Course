using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform A, B;
    public float speed;

    // Move object with script between two points continuously
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(A.position, B.position, time);
    }
}
