using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardInfo : MonoBehaviour {

    public static List<EnemyCard> thisCard = new List<EnemyCard>(new EnemyCard[1]);
    public List<EnemyCard> container = new List<EnemyCard>(new EnemyCard[1]);

    public int turnCost;
    public static int cardType;
    public static int damageValue;

    public static int routine;

    private int rand;

    // Use this for initialization
    void Start()
    {
        //CardDataBase.cardList[i];
        //DrawCard();
    }

    public void DrawCard()
    {
        if(BattleManager.stageLevel == 0)
        {
            thisCard[0] = EnemyCardDataBase.cardList[routine++];
            if (routine == 4)
                routine = 0;
        }

        //rand = Random.Range(0, EnemyCardDataBase.cardList.Count);
        //thisCard[0] = CardDataBase.cardList[rand];



        turnCost = thisCard[0].turnCost;
        cardType = thisCard[0].cardType;
        damageValue = thisCard[0].damageValue;


    }
    // Update is called once per frame
    void Update()
    {
    }
}
