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
        Debug.Log("덱 오픈");

        for (int i = 0; i < 6; i++)
        {
            Instantiate(card, spawnPoints[i]);
            cardClone[i] = GameObject.Find("Deck" + (i+1)).transform.Find("Card(Clone)").gameObject;
        }
        Debug.Log("덱에 카드 클론들 생성됨");
        //Debug.Log(PlayerDeck.playerDeck.Count);
    }

    public void DeckClose()
    {

        for(int i = 0; i < 6; i++)
        {
            uCard = cardClone[i].GetComponent<ThisCard>();

            PlayerDeck.playerDeck[i].index = uCard.index;
            PlayerDeck.playerDeck[i].itemName = uCard.itemName;
            PlayerDeck.playerDeck[i].itemDescription = uCard.itemDescription;
            PlayerDeck.playerDeck[i].itemType = uCard.itemType;
            PlayerDeck.playerDeck[i].turnCost = uCard.turnCost;
            PlayerDeck.playerDeck[i].cardType = uCard.cardType;
            PlayerDeck.playerDeck[i].damageValue = uCard.damageValue;
            Destroy(cardClone[i]);
        }
        Debug.Log("카드 클론들 다시 플레이어덱에 추가하고 삭제시킴");

        Deck.SetActive(false);
    }

}
