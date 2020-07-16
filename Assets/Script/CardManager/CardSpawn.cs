using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawn : MonoBehaviour {

    public int curCount = 0;
    public int maxCount = 0;
    public int curTime;
    public Transform[] spawnPoints;
    public GameObject card;

    public static int i = 0;

    public void Start()
    {

        //maxCount
    }

    private void Update()
    {
        if(maxCount == 4)
        {
            if (curCount < maxCount)
            {
                Instantiate(card, spawnPoints[0]);
                Instantiate(card, spawnPoints[1]);
                Instantiate(card, spawnPoints[2]);
                Instantiate(card, spawnPoints[3]);
                curCount = 4;
                //Debug.Log(spawnPoints[0]);
            }

            for (i = 0; i < 4; i++)
            {
                if (spawnPoints[i].childCount == 0)
                {
                    Instantiate(card, spawnPoints[i]);
                    curCount++;
                    break;
                }
            }
        }
        else if(maxCount == 6)
        {
            if (curCount < maxCount)
            {
                Instantiate(card, spawnPoints[0]);
                Instantiate(card, spawnPoints[1]);
                Instantiate(card, spawnPoints[2]);
                Instantiate(card, spawnPoints[3]);
                Instantiate(card, spawnPoints[4]);
                Instantiate(card, spawnPoints[5]);
                curCount = 6;
                //Debug.Log(spawnPoints[0]);
            }
        }
        
        

        
        //curTime += Time.deltaTime;
    }

}
