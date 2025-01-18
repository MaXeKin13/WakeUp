using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Jump Points
    public List<Transform> jumpPoints = new List<Transform>();


    [SerializeField] Player player;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            player.Jump(Vector3.up);
        }
    }
}
