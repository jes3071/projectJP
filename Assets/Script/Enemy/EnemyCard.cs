using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCard : MonoBehaviour {

    public List<Card> thisCard = new List<Card>(new Card[1]);
    public List<Card> container = new List<Card>(new Card[1]);

    public int turnCost;
    public static int cardType;
    public static int damageValue;

    private int rand;

    // Use this for initialization
    void Start()
    {
        //CardDataBase.cardList[i];

        
        //DrawCard();
    }

    public void DrawCard()
    {
        rand = Random.Range(0, CardDataBase.cardList.Count);

        //while (CardDataBase.cardList[rand].inPlayerHand == 1)
        //    rand = Random.Range(0, CardDataBase.cardList.Count);
        //Debug.Log("1");
        thisCard[0] = CardDataBase.cardList[rand];
        //Debug.Log("1");
        turnCost = thisCard[0].turnCost;
        cardType = thisCard[0].cardType;
        damageValue = thisCard[0].damageValue;
        //Debug.Log("1");


    }
    // Update is called once per frame
    void Update()
    {
        //DrawCard();
        //container[0] = thisCard[0];
    }
}
