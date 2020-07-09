using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawn : MonoBehaviour {

    public int curCount = 0;
    public int maxCount = 4;
    public int curTime;
    public Transform[] spawnPoints;
    public GameObject card;

    private void Update()
    {
        if (curCount < maxCount)
        {
            Instantiate(card, spawnPoints[0]);
            Instantiate(card, spawnPoints[1]);
            Instantiate(card, spawnPoints[2]);
            Instantiate(card, spawnPoints[3]);
            curCount = 4;
          }

        //curTime += Time.deltaTime;
    }

}
