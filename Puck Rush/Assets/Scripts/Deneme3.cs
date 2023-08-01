using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme3 : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float horizontalOran = 10f;
    [SerializeField] private float totalSpeed;

    [SerializeField] private float speed_A;
    [SerializeField] private float speed_D;

    [SerializeField] private float verticalSpeed = 10f;

    [SerializeField] private float rotationSpeed = 100f;

    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        totalSpeed = 180 / horizontalOran;
        horizontalSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed_D = (int)(GetPuckRotationY() % 180) / horizontalOran;
        speed_A = totalSpeed - speed_D;

        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("sola döndük");
            if ((GetPuckRotationY() % 360) < 180)
            {
                horizontalSpeed = speed_A;
            }
            else if ((GetPuckRotationY() % 360) > 180)
            {
                horizontalSpeed = -speed_A;
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("saða döndük");
            if ((GetPuckRotationY() % 360) < 180)
            {
                horizontalSpeed = speed_D;
            }
            else if ((GetPuckRotationY() % 360) > 180)
            {
                horizontalSpeed = -speed_D;

            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        //transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);


        Vector3 movementDirection = transform.forward * verticalSpeed;

        rb.velocity = new Vector3(horizontalSpeed, rb.velocity.y, movementDirection.z);
    }

    private float GetPuckRotationY()
    {
        float rotation = rb.transform.localEulerAngles.y;
        return rotation;
    }
}
