using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    [SerializeField] private Collider walkablePlat;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            walkablePlat.isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            walkablePlat.isTrigger = false;
        }
    }
}
