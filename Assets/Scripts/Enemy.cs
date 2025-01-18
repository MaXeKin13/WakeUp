using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float timeToReach = 1f;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private float distance;

    private Vector3 rightPos;
    private Vector3 leftPos;

    public bool isNightmare = false;
    private void Start()
    {
        if(isNightmare)
            GameManager.instance.onNightmare += NightmareMove;
       rightPos = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
       leftPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if(!isNightmare )
            StartCoroutine(MoveRight(waitTime));
        else
        {
            GameManager.instance.nightmareObjects.Add(this.gameObject);
            GameManager.instance.onNightmareFinish += DisableNightmare;
            gameObject.SetActive(false);
            
        }


    }
    private void NightmareMove()
    {
        StartCoroutine(WaitTillLeftRight());
        IEnumerator WaitTillLeftRight()
        {
            bool eventTriggered = false;
            GameManager.instance.isLeftRight += () => eventTriggered = true;
            //transform.position = rightPos;
            yield return new WaitUntil(() => eventTriggered);

            Debug.Log("trigger");
            StartCoroutine(MoveLeft(waitTime));
            Debug.Log("MOVE");
        }
    }
    private IEnumerator MoveRight(float waitTime)
    {
        GameManager.instance.IsLeftRight();
        transform.DORotate(new Vector3(0, 0, 0), waitTime);
        yield return new WaitForSeconds(waitTime);
        transform.DOMove(rightPos, timeToReach).SetEase(Ease.Linear).OnComplete(()=> StartCoroutine(MoveLeft(timeToReach)));
    }
    private IEnumerator MoveLeft(float watiTime)
    {
        //GameManager.instance.IsLeftRight();
        transform.DORotate(new Vector3(0,-180,0), watiTime);
        yield return new WaitForSeconds(watiTime);
        transform.DOMove(leftPos, timeToReach).SetEase(Ease.Linear).OnComplete(() => StartCoroutine(MoveRight(timeToReach)));
    }

    public void DisableNightmare()
    { StopAllCoroutines(); }
    

}
