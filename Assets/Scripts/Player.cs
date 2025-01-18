using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 10f;
    public float moveSpeed = 1f;
    
    private Rigidbody rb;


    private bool pressingJump = false;
    public bool airborn = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public IEnumerator Jump(Vector3 dir)
    {
        //rb.AddForce(Vector3.up*jumpPower, ForceMode.Impulse);
        
        while (pressingJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);

            //always keep this velocity until let go
            yield return new WaitForFixedUpdate();
        }
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Negative value for left

        // Create movement vector (only moving left/right on the X-axis)
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);

        // Apply the movement using Rigidbody's velocity
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, rb.velocity.z);


        if (Input.GetMouseButtonDown(0))
        {
            pressingJump = true;
            StartCoroutine(Jump(Vector3.up));
        }
        if(pressingJump && Input.GetMouseButtonUp(0))
        {
            pressingJump = false;
            StartCoroutine(StopJumping());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Platform"))
        {
            airborn = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            airborn = true;
        }
    }

    private IEnumerator StopJumping()
    {
        while(airborn)
        {
            Debug.Log("Downwards");
            rb.AddForce(Vector3.down * 100f, ForceMode.Force);
            yield return null;
        }
    }
    private void FixedUpdate()
    {
        
    }

}
