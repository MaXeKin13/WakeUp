using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Jump(Vector3 dir)
    {
        rb.AddForce(Vector3.up*10f, ForceMode.Impulse);
    }
}
