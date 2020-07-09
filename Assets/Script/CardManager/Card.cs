using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card {
   
    public string itemName;
    public string itemDescription;
    public int reinforceValue;
    public int turnCost;
    public int cardType;
    public int damageValue;

    //public Sprite thisImage;

    public Card()
    {


    }

    public Card(string ItemName, string ItemDescription, int ReinforceVale, int TurnCost, int CardType, int DamageValue)//, Sprite ThisImage)
    {

        itemName = ItemName;
        itemDescription = ItemDescription;
        reinforceValue = ReinforceVale;
        turnCost = TurnCost;
        cardType = CardType;
        damageValue = DamageValue;

        //thisImage = ThisImage;

    }
}
