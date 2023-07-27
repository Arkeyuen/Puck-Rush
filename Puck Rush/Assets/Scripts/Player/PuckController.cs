using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    [Header("Forward Move Settings")]
    [SerializeField] private float puckNormalSpeed = 5f;
    [SerializeField] private float puckCurrentSpeed;

    [Header("Breake Settings")]
    [SerializeField] private float autoDeceleration = 1f;
    [SerializeField] private float playerBreake = 1f;

    [Header("Rotation Move Settings")]
    [SerializeField] private float rotationSpeed = 10f;
    private Vector3 _rotation = Vector3.up;

    [Header("Start Boost Settings")]
    [SerializeField] private float startBoostSpeed = 10f;
    [SerializeField] private float startBoostTime = 2f;
    private bool isStartBoosting = false;
    private bool canStartBoosting = false;
    private float boostTimer = 0f;

    [Header("Puck Game Boost Settings ")]
    [SerializeField] private float puckGameBoostSpeed = 10f;
    [SerializeField] private int maxBoostUsage = 3;
    private int boostUsage = 0;
    private bool canBoostInGame = false;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int maxJumpUsage = 3;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    private int jumpUsage = 0;
    private bool isJumping = false;
    //duruyorsa zýplayamasýn


    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        jumpUsage = 0;
    }

    void Update()
    {
        MoveForward();

        ManageControll();

        Jump(jumpForce);

        //StartBoosting();

        GameBoosting();//cooldown olsun //boost basarken duvarýn içinden geçip düþüyor
    }

    private void StartBoosting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canStartBoosting = true;
        }
        if (canStartBoosting)
        {
            puckCurrentSpeed = startBoostSpeed;
            boostTimer += Time.deltaTime;
            if (boostTimer > startBoostTime)
            {
                puckCurrentSpeed = puckNormalSpeed;
                boostTimer = 0f;
                canStartBoosting = false;
            }

        }
    }

    private void GameBoosting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (maxBoostUsage > boostUsage)
            {
                canBoostInGame = true;
            }
            else canBoostInGame = false;


            if (canBoostInGame)
            {
                puckCurrentSpeed += puckGameBoostSpeed;
                boostUsage++;
                Debug.Log("boost Usage " + boostUsage);
            }
        }

    }

    private void Jump(float JumpForce)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsGrounded())
            {
                isJumping = true;
            }
            if (jumpUsage < maxJumpUsage)
            {
                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
                    jumpUsage++;
                    Debug.Log("Jump Usage : " + jumpUsage);
                }
            }
        }

    }

    private void MoveForward()
    {
        // Move the puck forward at its current speed.
        transform.position += transform.forward * puckCurrentSpeed * Time.deltaTime;
        if (!isJumping)
        {
            DecreaseSpeed(autoDeceleration);
        }

        StopPuck();
    }

    private void StopPuck()
    {
        if (puckCurrentSpeed < 0.1f)
        {
            puckCurrentSpeed = 0.0f;
            //respawný buraya yaz
        }
    }

    private void DecreaseSpeed(float speed)
    {
        puckCurrentSpeed -= speed * Time.deltaTime;
    }

    private void ManageControll()
    {
        if (puckCurrentSpeed > 0 && Input.GetKey(KeyCode.A) && !isJumping)
        {
            transform.Rotate(-_rotation * rotationSpeed * Time.deltaTime);
        }

        if (puckCurrentSpeed > 0 && Input.GetKey(KeyCode.D) && !isJumping)
        {
            transform.Rotate(_rotation * rotationSpeed * Time.deltaTime);
        }

        if (puckCurrentSpeed > 0 && Input.GetKey(KeyCode.S) && !isJumping)
        {
            DecreaseSpeed(playerBreake);
        }
    }

    bool IsGrounded()
    {
        isJumping = false;
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    public static void StopAll()
    {
        //Her þey duracak.
    }
}
