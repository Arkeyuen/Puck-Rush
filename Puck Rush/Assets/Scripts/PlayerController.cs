using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [Header("Puck Settings")]
    [SerializeField] private float puckNormalspeed = 5f;
    [SerializeField] private float puckCurrentSpeed;
    [SerializeField] private float deceleration = 1f; //oyuncu da fren yapabilsin
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    public bool isJumping = false; //oyuncuya sýnýrlý sayýda verilecek
    //duruyorsa zýplayamasýn

    [Header("Booster Settings")]
    [SerializeField] private float puckBoostSpeed = 10f;
    [SerializeField] private float boostTime = 1f;

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 10f;

    private float boostTimer = 0f;
    private bool boosting = false;
    private Vector3 _rotation = Vector3.up;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boosting = false;
    }

    void Update()
    {
        //level baþýnda otomatik fýrlatýlacak.
        // Check if the left mouse button is pressed.//oyuncuya sýnýrlý sayýda verilecek
        if (Input.GetMouseButtonDown(0))
        {
            boosting = true;
            puckCurrentSpeed = puckBoostSpeed;
        }

        if (!IsGrounded())
        {
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); 
        }

        // Move the puck forward at its current speed.
        transform.position += transform.forward * puckCurrentSpeed * Time.deltaTime;

        // Decelerate the puck over time on ground.
        if (!boosting && !isJumping) //oyuncu boostlarken sürtünme etkilesin.
        {
            puckCurrentSpeed -= deceleration * Time.deltaTime;
        }

        // If the puck's speed is below a certain threshold, stop it.
        if (puckCurrentSpeed < 0.1f)
        {
            puckCurrentSpeed = 0.0f;
        }

        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer > boostTime)
            {
                puckCurrentSpeed = puckNormalspeed;
                boostTimer = 0f;
                boosting = false;
            }
        }

        if (puckCurrentSpeed == 0 && Input.GetMouseButtonDown(1))
            Debug.Log("spawned");

        else
        {
            if (puckCurrentSpeed > 0 && Input.GetKey(KeyCode.A) && !isJumping)
            {
                transform.Rotate(-_rotation * rotationSpeed * Time.deltaTime);
            }

            if (puckCurrentSpeed > 0 && Input.GetKey(KeyCode.D) && !isJumping)
            {
                transform.Rotate(_rotation * rotationSpeed * Time.deltaTime);
            }
        }


    }

    bool IsGrounded()
    {
        isJumping = false;
        return Physics.CheckSphere(groundCheck.position, .1f, ground); 
    }

}