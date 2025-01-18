using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 ogPos;
    // Start is called before the first frame update
    void Start()
    {
        ogPos = transform.position;
       MoveBackground();
    }

    private void MoveBackground()
    {
        transform.position = ogPos;
        transform.DOMove(new Vector3(transform.position.x + 50f, transform.position.y, transform.position.z), speed).SetEase(Ease.Linear).OnComplete(()=> MoveBackground());
    }

    
}
