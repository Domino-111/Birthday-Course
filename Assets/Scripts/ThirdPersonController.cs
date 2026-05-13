using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float walkSpeed = 3, runSpeed = 7, speed = 0;

    public Transform modelMesh;

    private Rigidbody rb;
    private Vector3 movementVector, playerDirection;

    public float jumpForce = 5;
    public bool grounded = true;

    private Animator ani;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        playerDirection = transform.forward;
        ani = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //Perform a box cast to detect if we're grounded
        grounded = Physics.BoxCast(transform.position + Vector3.up, Vector3.one * 0.5f, Vector3.down, modelMesh.rotation, 0.7f);

        //Flattened versions of the Camera's direction. Removing their y-axis from play
        Vector3 forwardFlat = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 sideFlat = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        //Calculation of movement using WASD. Normalized to avoid inappropriate speeds (diagonals)
        movementVector = (forwardFlat * Input.GetAxis("Vertical")) + (sideFlat * Input.GetAxis("Horizontal"));
        movementVector.Normalize();

        //Rotating player direction towards the movement vector, locking rotation forward if RMB is held. SLERP: sperical interpolation, use for rotation lerping
        if (Input.GetMouseButton(1))
        {
            playerDirection = Vector3.Slerp(playerDirection, forwardFlat, 5 * Time.deltaTime);
        }

        else
        {
            playerDirection = Vector3.Slerp(playerDirection, movementVector.magnitude > 0 ? movementVector : playerDirection, 5 * Time.deltaTime);
        }

        modelMesh.rotation = Quaternion.LookRotation(playerDirection);

        //Jumping if SPACE pressed AND we're grounded
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        //Lerping of SPEED towards 0, walkspeed and runspeed, given condition. MOVE TOWARDS: lerping with a set step
        if (movementVector.magnitude > 0)
        {
            speed = Mathf.MoveTowards(speed, Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed, 2 * Time.deltaTime);
        }

        else
        {
            speed = Mathf.MoveTowards(speed, 0, 5 * Time.deltaTime);
        }

        //Animation Updates
        ani.SetBool("Walking?", movementVector.magnitude > 0);

        ani.SetBool("Running?", Input.GetKey(KeyCode.LeftShift));

        ani.SetBool("Locked?", Input.GetMouseButton(1));

        ani.SetFloat("X", Input.GetAxis("Horizontal") * (Input.GetKey(KeyCode.LeftShift) ? 2 : 1));
        ani.SetFloat("Z", Input.GetAxis("Vertical") * (Input.GetKey(KeyCode.LeftShift) ? 2 : 1));

        ani.SetBool("Grounded?", grounded);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = (movementVector * speed) + (Vector3.up * rb.linearVelocity.y);
    }
}
