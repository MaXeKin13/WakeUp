using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 1f;
    
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Jump(Vector3 dir)
    {
        rb.AddForce(Vector3.up*10f, ForceMode.Impulse);
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Negative value for left

        // Create movement vector (only moving left/right on the X-axis)
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);

        // Apply the movement using Rigidbody's velocity
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, rb.velocity.z);
    }

    private void MoveLeft()
    {
        
    }
}
