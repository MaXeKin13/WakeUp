using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Jump Points

    public static GameManager instance;

    [SerializeField] Player player;

    [SerializeField] RespawnZone respawnZone;

    public List<GameObject> nightmareObjects = new List<GameObject>();

    

    public event Action onNightmare;
    public event Action onNightmareFinish;
    public event Action isLeftRight;
    private bool isNightmare = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach(GameObject obj in nightmareObjects)
        {
            obj.SetActive(false);
        }    
    }
    private void Update()
    {
        
    }

    public void IsLeftRight()
    {
        isLeftRight?.Invoke();
    }
    public void Nightmare()
    {
        if (!isNightmare)
        {
            isNightmare = true;
            StartCoroutine(NightmareRoutine());
            IEnumerator NightmareRoutine()
            {
                foreach (GameObject obj in nightmareObjects)
                {
                    obj.SetActive(true);

                }
                respawnZone.speed = 0.11f;
                onNightmare?.Invoke();
                yield return new WaitForSeconds(5f);
                EndNightmare();
            }
        }
    }

    public void EndNightmare()
    {
        Debug.Log("EndNightmare");
        isNightmare = false ;
        onNightmareFinish?.Invoke();
        foreach (GameObject obj in nightmareObjects)
        {
            
            obj.SetActive(false);
            
        }
        respawnZone.speed = 0.1f;
    }
}
