using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject stairs;
    public GameObject under, surface;
    public float speed;
    public bool spawned = false;

    // When the player collides with the checkpoint hitbox it'll spawn a staircase so if they fall they can get back up 
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && spawned == false)
        {
            Instantiate(stairs, transform, under);
            stairs.transform.position = Vector3.MoveTowards(under.transform.position, surface.transform.position, speed * Time.deltaTime);
            spawned = true;
        }
    }
}
