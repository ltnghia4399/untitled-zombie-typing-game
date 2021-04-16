using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(Vector3.forward * moveSpeed * Time.fixedDeltaTime, ForceMode.Force);

        rb.velocity = Vector3.forward * Time.fixedDeltaTime * moveSpeed;
    }
}
