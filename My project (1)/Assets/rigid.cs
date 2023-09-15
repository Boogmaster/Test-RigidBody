using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public Camera cam;

    public float walkSpeed = 5;
    public float speedLimiter = 0.7f;
    public float lookSpeed = 5;

    float inputHorizontal;
    float inputVertical;
    float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.H))
        {
            rotationX += 1;
        }
        if (Input.GetKey(KeyCode.K))
        {
            rotationX -= 1;
        }
        cam.transform.localRotation = Quaternion.Euler(0, rotationX, 0);
    }

    private void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal = speedLimiter;
                inputVertical = speedLimiter;
            }

            rb.velocity = new Vector3(inputHorizontal, 0, inputVertical);
        }
    }
}


