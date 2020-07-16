using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawn : MonoBehaviour {

    public List<Card> dropCard = new List<Card>(new Card[1]);

    public int curCount = 0;
    public int maxCount = 0;
    public int curTime;
    public Transform[] spawnPoints;
    public GameObject card;

    public GameObject Deck;
    public GameObject[] cardClone;
    public static int i = 0;

    public static ThisCard uCard;

    public void Start()
    {
        Deck = GameObject.Find("FixedUIHelper").transform.Find("UIBattlePlayerDeckPopup").gameObject;
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
    }

    public void DeckOpen()
    {
        Deck.SetActive(true);
        //Debug.Log(Deck);
        // if (maxCount == 6)
        for(int i = 0; i < 6; i++)
        {
            Instantiate(card, spawnPoints[i]);
            cardClone[i] = GameObject.Find("Deck" + (i+1)).transform.Find("Card(Clone)").gameObject;
        }
    }

    public void DeckClose()
    {

        for(int i = 0; i < 6; i++)
        {
            uCard = cardClone[i].GetComponent<ThisCard>();

            dropCard[0].itemName = uCard.itemName;
            dropCard[0].itemDescription = uCard.itemDescription;
            dropCard[0].itemType = uCard.itemType;
            dropCard[0].turnCost = uCard.turnCost;
            dropCard[0].cardType = uCard.cardType;
            dropCard[0].damageValue = uCard.damageValue;

            PlayerDeck.playerDeck.Add(new Card(dropCard[0].itemName, dropCard[0].itemDescription,
                   dropCard[0].itemType, dropCard[0].turnCost, dropCard[0].cardType, dropCard[0].damageValue,
                   1, 0, null, null));
            Destroy(cardClone[i]);
        }
        

        Deck.SetActive(false);
    }

}
