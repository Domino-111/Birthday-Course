using UnityEngine;

public class FallCounter : MonoBehaviour
{
    // Reference to Game Manager script
    public GameManager gm;

    public void OnCollisionEnter(Collision collision)
    {
        // When the player collides with the ground hitbox increase the fall counter by 1
        if (collision.transform.CompareTag("Player"))
        {
            gm.falls += 1;
        }
    }
}
