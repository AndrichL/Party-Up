using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float moveSpeed = 1; // public for powerUps
    public float jumpSpeed = 1; // public for powerUps
    public float Knockback = 1; // public for powerUps
    [SerializeField] Transform jumpCheckPoint; // The point where the ray gets cast from to check if the player is grounded
    public Rigidbody rigidbody; // Public so it can be accessed by "Shooting Script"


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
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;

        Vector3 move = new Vector3(x, 0f, 0f);
        move = move * Time.deltaTime;
        transform.position += move;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
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
