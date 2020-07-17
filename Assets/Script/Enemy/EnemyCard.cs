using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnemyCard{

    public int index;
    public string itemName;
    public string itemDescription;
    public int turnCost;
    public int cardType;
    public int damageValue;
    public int monsterType;


    public EnemyCard(int Index, string ItemName, string ItemDescription, int TurnCost,
        int CardType, int DamageValue, int MonsterType)
    {
        index = Index;
        itemName = ItemName;
        itemDescription = ItemDescription;
        turnCost = TurnCost;
        cardType = CardType;
        damageValue = DamageValue;
        monsterType = MonsterType;
    }
}
