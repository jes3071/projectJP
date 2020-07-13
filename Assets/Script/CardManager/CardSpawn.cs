using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawn : MonoBehaviour {

    public int curCount = 0;
    public int maxCount = 4;
    public int curTime;
    public Transform[] spawnPoints;
    public GameObject card;

    public static int i = 0;

    private void Update()
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
    

        //curTime += Time.deltaTime;
    }

}
