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
        if(BattleManager.stageLevel == -1)
        {
            if(EnemyCardDataBase.cardList[routine].monsterType == 0)
            {
                thisCard[0] = EnemyCardDataBase.cardList[routine++];
                if (routine == 2)
                    routine = 0;
            }
        }
        if (BattleManager.stageLevel == 0)
        {
            if(BattleManager.randomMonster == 0)
            {
                if (routine < 2)
                {
                    routine = 2;
                }
                if (EnemyCardDataBase.cardList[routine].monsterType == 1)
                {
                    thisCard[0] = EnemyCardDataBase.cardList[routine++];

                    if (routine == 4)
                        routine = 2;
                }
            }
            else if (BattleManager.randomMonster == 1)
            {
                if (routine < 4)
                {
                    routine = 4;
                }
                if (EnemyCardDataBase.cardList[routine].monsterType == 2)
                {
                    thisCard[0] = EnemyCardDataBase.cardList[routine++];

                    if (routine == 6)
                        routine = 4;
                }
            }
        }
        if (BattleManager.stageLevel == 1)
        {
            if (BattleManager.randomMonster == 0)
            {
                if (routine < 6)
                {
                    routine = 6;
                }
                if (EnemyCardDataBase.cardList[routine].monsterType == 3)
                {
                    thisCard[0] = EnemyCardDataBase.cardList[routine++];

                    if (routine == 9)
                        routine = 6;
                }
            }
            else if (BattleManager.randomMonster == 1)
            {
                if (routine < 9)
                {
                    routine = 9;
                }
                if (EnemyCardDataBase.cardList[routine].monsterType == 4)
                {
                    thisCard[0] = EnemyCardDataBase.cardList[routine++];

                    if (routine == 13)
                        routine = 9;
                }
            }
            else if (BattleManager.randomMonster == 2)
            {
                if (routine < 13)
                {
                    routine = 13;
                }
                if (EnemyCardDataBase.cardList[routine].monsterType == 5)
                {
                    thisCard[0] = EnemyCardDataBase.cardList[routine++];

                    if (routine == 16)
                        routine = 13;
                }
            }
        }
        if (BattleManager.stageLevel == 2)
        {
            if (BattleManager.randomMonster == 0)
            {
                if (routine < 16)
                {
                    routine = 16;
                }
                if (EnemyCardDataBase.cardList[routine].monsterType == 6)
                {
                    thisCard[0] = EnemyCardDataBase.cardList[routine++];

                    if (routine == 22)
                        routine = 16;
                }
            }
            else if (BattleManager.randomMonster == 1)
            {
                if (routine < 22)
                {
                    routine = 22;
                }
                if (EnemyCardDataBase.cardList[routine].monsterType == 7)
                {
                    thisCard[0] = EnemyCardDataBase.cardList[routine++];

                    if (routine == 34)
                        routine = 22;
                }
            }
        }
        if (BattleManager.stageLevel == 3)
        {
            if (routine < 34)
            {
                routine = 34;
            }
            if (EnemyCardDataBase.cardList[routine].monsterType == 8)
            {
                thisCard[0] = EnemyCardDataBase.cardList[routine++];

                if (routine == 44)
                    routine = 34;
            }
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
