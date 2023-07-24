using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Puck Settings")]
    [SerializeField] private float puckNormalspeed = 5f;
    [SerializeField] private float puckCurrentSpeed;
    [SerializeField] private float deceleration = 1f;

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
        boosting = false;
    }

    void Update()
    {

        // Check if the left mouse button is pressed.
        if (Input.GetMouseButtonDown(0))
        {
            boosting = true;
            puckCurrentSpeed = puckBoostSpeed;
        }

        // Move the puck forward at its current speed.
        transform.position += transform.forward * puckCurrentSpeed * Time.deltaTime;

        // Decelerate the puck over time.
        if (!boosting)
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
            if (puckCurrentSpeed > 0 && Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-_rotation * rotationSpeed * Time.deltaTime);
            }

            if (puckCurrentSpeed > 0 && Input.GetKey(KeyCode.D))
            {
                transform.Rotate(_rotation * rotationSpeed * Time.deltaTime);
            }
        }

        
    }

}