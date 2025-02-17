using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 10f;
    public float moveSpeed = 1f;

    public float maxJumpHeight;
    
    private Rigidbody rb;


    private bool pressingJump = false;
    public bool airborn = false;
    

    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }
    public IEnumerator Jump(Vector3 dir)
    {
        PlayAnim("Jump");
        //yield return new WaitForSeconds(0.1f);
        float initialYPos = transform.position.y;
        //rb.AddForce(Vector3.up*jumpPower, ForceMode.Impulse);

        while (pressingJump && transform.position.y < initialYPos + maxJumpHeight)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);

            //always keep this velocity until let go
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(StopJumping());
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Negative value for left

        // Create movement vector (only moving left/right on the X-axis)
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);

        // Apply the movement using Rigidbody's velocity
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, rb.velocity.z);


        if (Input.GetMouseButtonDown(0) && !airborn)
        {
            pressingJump = true;
            StartCoroutine(Jump(Vector3.up));
        }
        if(pressingJump && Input.GetMouseButtonUp(0))
        {
            
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            GameManager.instance.Nightmare();
        }
        if(other.transform.CompareTag("Finish"))
        {
            StartCoroutine(Goal());
        }
    }
    public GameObject Canvas;
    private IEnumerator Goal()
    {
        GameManager.instance.respawnZone.gameObject.SetActive(false);
        Canvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        Application.Quit();
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
        pressingJump = false;
        //
        while (airborn)
        {
            rb.AddForce(Vector3.down * 100f, ForceMode.Force);
            yield return null;
        }
        PlayAnim("Fall");
    }
    private void FixedUpdate()
    {
        
    }


    private void PlayAnim(string animName)
    {
        if(animName != null) 
        animator.Play(animName);
    }

}
