using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public float sensitivity = 120;
    public float minClamp = -50, maxClamp = 50;
    public GameManager gm;

    void Start()
    {
        
    }

    void Update()
    {
        // Rotate our pivot point globally on y rotation and locally on x rotation. Stops any rolling rotations
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0, Space.World);
        transform.Rotate(-Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime, 0, 0, Space.Self);

        // Clamp the current x rotation to min and max clamp
        float xRot = transform.eulerAngles.x;

        // Ensure rotation is set to a -180, 180 range instead of 0, 360
        if (xRot > 180)
        {
            xRot -= 360;
        }

        // Limit rotation between 2 values we set
        xRot = Mathf.Clamp(xRot, minClamp, maxClamp);
        transform.eulerAngles = new Vector3(xRot, transform.eulerAngles.y, 0);

        // Lock cursor only after the game has started playing
        if (gm.isPlaying == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
