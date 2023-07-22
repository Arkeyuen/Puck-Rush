using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float deceleration;

    void Update()
    {
        // Check if the left mouse button is pressed.
        if (Input.GetMouseButtonDown(0))
        {
            // Move the puck forward at its current speed.
            this.transform.Translate(0, 0, speed);
        }
        // Decelerate the puck over time.
        speed -= deceleration * Time.deltaTime;

        // If the puck's speed is below a certain threshold, stop it.
        if (speed < 0.1f)
        {
            speed = 0.0f;
        }
    }
}