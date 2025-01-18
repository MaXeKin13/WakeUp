using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Jump Points

    public static GameManager instance;

    [SerializeField] Player player;

    public List<GameObject> nightmareObjects = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        
    }

    public void Nightmare()
    {

        IEnumerator NightmareRoutine()
        {

            yield return new WaitForSeconds(5f);
        }
    }
}
