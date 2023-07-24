using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    private bool canMove;
    private float boostTimer = 0f;
    Rigidbody rb;


    [Header("Puck Forward Move Settings")]
    [SerializeField] private float puckNormalspeed = 5f;
    [SerializeField] private float puckCurrentSpeed;
    [SerializeField] private float deceleration = 1f; //oyuncu da fren yapabilsin


    [Header("Puck Rotation Move Settings")]
    [SerializeField] private float rotationSpeed = 10f;
    private Vector3 _rotation = Vector3.up;


    [Header("Puck Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    public bool isJumping = false; //oyuncuya sýnýrlý sayýda verilecek
    //duruyorsa zýplayamasýn


    [Header("Puck Booster Settings")]
    [SerializeField] private float puckBoostSpeed = 10f;
    [SerializeField] private float puckBoostTime = 1f;
    private bool IsPuckBoosting;

    [Header("Start Booster Settings")]
    [SerializeField] private float startBoostSpeed = 10f;
    [SerializeField] private float startboostTime = 1f;
    private bool IsStartBoosting;


    private bool boosting = false; //done





    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boosting = false;
    }

    private void Update()
    {
        if (canMove)
        {
            MoveForward();

            ManageControl();
        }
    }

    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Game)
            StartMoving();
        else if (gameState == GameManager.GameState.GameOver)
            StopMoving();
        else if (gameState == GameManager.GameState.LevelComplate)
            StopMoving();
    }

    private void StartMoving()
    {
        canMove = true;
        //playerAnimator.Run();
    }

    private void StopMoving()
    {
        canMove &= false;
        //PlayerAnimator.Idle();
    }

    private void MoveForward()
    {
        // Move the puck forward at its current speed.
        transform.position += transform.forward * puckCurrentSpeed * Time.deltaTime;

        // Decelerate the puck over time on ground.
        if (!boosting && !isJumping) //oyuncu boostlarken sürtünme etkilesin.
        {
            puckCurrentSpeed -= deceleration * Time.deltaTime;
        }
    }

    private void ManageControl()
    {

    }

    private void Jump(float JumpForce)
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
    }

    private void BoosterOnStart()
    {

    }

    private void BoosterInGame()
    {

    }

    private void checkPuck()
    {
        // If the puck's speed is below a certain threshold, stop it.
        if (puckCurrentSpeed < 0.1f)
        {
            puckCurrentSpeed = 0.0f;
        }
    }

    bool IsGrounded()
    {
        isJumping = false;
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}