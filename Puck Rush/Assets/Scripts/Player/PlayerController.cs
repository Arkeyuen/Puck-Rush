using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   /* public static PlayerController instance;

    private bool canMove;
    private bool canJump;
    private float boostTimer = 0f;
    Rigidbody rb;


    [Header("Puck Forward Move Settings")]
    [SerializeField] public float puckNormalspeed = 5f;
    [SerializeField] public float puckCurrentSpeed;

    [Header("Puck Deceleration Speed")]
    [SerializeField] private float autoDeceleration = 1f; // zemin sürtünmesi 
    [SerializeField] private float playerDeceleration = 1f; // oyuncu freni


    [Header("Puck Rotation Move Settings")]
    [SerializeField] private float rotationSpeed = 10f;
    private Vector3 _rotation = Vector3.up;


    [Header("Puck Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    private bool isJumping = false;
    //duruyorsa zýplayamasýn


    [Header("Puck Booster Settings")]
    [SerializeField] private float puckBoostSpeed = 10f;
    [SerializeField] private float puckBoostTime = 1f;
    //[SerializeField] private float maxBoost = 3f;
    //private float maxBoostUsage;
    private bool canPuckBoosting;

    [Header("Start Booster Settings")]
    [SerializeField] private float startBoostSpeed = 10f;
    [SerializeField] private float startBoostTime = 1f;
    private bool canStartBoosting;
    private bool isStartBoosting;



    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallBack;

        rb = GetComponent<Rigidbody>();
        canPuckBoosting = false;
        canStartBoosting = false;
        canJump = false;
        canPuckBoosting = false;
        //maxBoost = 0f;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallBack;
    }

    private void Update()
    {
        if (canMove)
        {
            MoveForward();

            ManageControl();

        }


        checkPuck();
        //level baþýnda otomatik fýrlatýlacak.
        // Check if the left mouse button is pressed.//oyuncuya sýnýrlý sayýda verilecek
        if (Input.GetMouseButtonDown(0)) // start boostu
        {
            if (GameManager.Instance.IsGameState())
            {
                canPuckBoosting = true;
                if (canPuckBoosting)
                {
                    puckCurrentSpeed += puckBoostSpeed;
                    //maxBoostUsage++;
                    // Debug.Log(maxBoostUsage);
                }
            }
            else
            {
                canStartBoosting = true;
                GameManager.Instance.SetGameState(GameManager.GameState.Game);// bunu ilerde menuye al
                puckCurrentSpeed = startBoostSpeed;

            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }

        if (!IsGrounded())
        {
            isJumping = true;
        }


        if (canJump)
        {
            Jump(jumpForce);
        }

        if (canStartBoosting)
            BoosterOnStart();

        if (canPuckBoosting)
        {
            BoosterInGame();
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


    private void MoveForward()
    {
        // Move the puck forward at its current speed.
        transform.position += transform.forward * puckCurrentSpeed * Time.deltaTime;

        // Decelerate the puck over time on ground.
        if (!isStartBoosting && !isJumping) //oyuncu boostlarken sürtünme etkilesin.
        {
            DecreseSpeed(autoDeceleration);
        }
    }
    private void DecreseSpeed(float speed)
    {
        puckCurrentSpeed -= speed * Time.deltaTime;
    }

    private void ManageControl()
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
            DecreseSpeed(playerDeceleration);
        }
    }

    private void Jump(float JumpForce)
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {

            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
        }

    }

    private void BoosterOnStart()
    {
        if (canStartBoosting)
        {
            isStartBoosting = true;
            boostTimer += Time.deltaTime;
            if (boostTimer > startBoostTime)
            {
                puckCurrentSpeed = puckNormalspeed;
                boostTimer = 0f;
                isStartBoosting = false;
                canStartBoosting = false;
            }
        }
    }

    private void BoosterInGame()
    {
        if (canPuckBoosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer > puckBoostTime)
            {
                //puckCurrentSpeed = puckNormalspeed;
                boostTimer = 0f;
                canPuckBoosting = false;
            }
        }
    }

    private void checkPuck()
    {
        // If the puck's speed is below a certain threshold, stop it.
        if (puckCurrentSpeed < 0.1f)
        {
            if (GameManager.Instance.IsGameState())
                GameManager.Instance.SetGameState(GameManager.GameState.GameOver);
            if (GameManager.Instance.IsThisGameState(GameManager.GameState.GameOver)) bu kod hareketi bitiricek
                return;
            puckCurrentSpeed = 0.0f;

        }
    }

    private void RespawnPunk()
    {
        //punk hýzý 0 ken spawnpointe spawnla
    }

    bool IsGrounded()
    {
        isJumping = false;
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    private void StartMoving()
    {
        canMove = true;
        //playerAnimator.Run();
    }

    private void StopMoving()
    {
        canMove = false;
        //PlayerAnimator.Idle();
    }
*/
}