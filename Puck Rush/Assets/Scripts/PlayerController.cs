using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    Rigidbody rb;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;

    [Header("Ground")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Oyuncu saða sola kontrolü
        float verticalInput = 1f; // Karakterin otomatik olarak ileri doðru koþmasý

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded()) // Jump'a basar ve yerde ise
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
