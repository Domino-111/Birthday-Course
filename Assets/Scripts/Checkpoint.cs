using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject stairs;
    public GameObject under, surface;
    public float speed;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Instantiate(stairs, transform, under);
        }
    }
}
