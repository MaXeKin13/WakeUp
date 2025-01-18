using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float timeToReach = 1f;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private float distance;

    private Vector3 rightPos;
    private Vector3 leftPos;


    private void Start()
    {
       rightPos = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
       leftPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        MoveRight(waitTime);

    }
    private IEnumerator MoveRight(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.DOMove(rightPos, timeToReach).SetEase(Ease.Linear).OnComplete(()=> MoveLeft(0.5f));
    }
    private IEnumerator MoveLeft(float watiTime)
    {
        yield return new WaitForSeconds(watiTime);
        transform.DOMove(leftPos, timeToReach).SetEase(Ease.Linear).OnComplete(() => MoveRight(0.5f));
    }

}
