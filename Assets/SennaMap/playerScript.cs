using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float moveSpeed = 1; // public for powerUps
    public float jumpSpeed = 1; // public for powerUps
    public float Knockback = 1; // public for powerUps
    [SerializeField] Transform jumpCheckPoint; // The point where the ray gets cast from to check if the player is grounded
    public Rigidbody rigidbody; // Public so it can be accessed by "Shooting Script"

    private Vector3 InputVector;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //InputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        //rigidbody.velocity = InputVector * moveSpeed;

        float x = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity += new Vector3(x, 0, 0) * moveSpeed * Time.fixedDeltaTime;
        rigidbody.velocity.Normalize();

        if (x == 0)
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (GroundCheck())
        {
            rigidbody.velocity = Vector2.up * jumpSpeed;
        }
        else { }
    }

    public bool GroundCheck()
    {
        return Physics.Raycast(jumpCheckPoint.position, Vector3.down, .1f);
    }
}
