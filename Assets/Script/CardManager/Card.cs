using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card {
   
    public string itemName;
    public string itemDescription;
    public int itemType;
    public int turnCost;
    public int cardType;
    public int damageValue;
    public int inPlayerDeck;
    public int inPlayerHand;
    public Sprite cardImage;
    public Sprite thisImage;
    

    public Card(string ItemName, string ItemDescription, int ItemType, int TurnCost,
        int CardType, int DamageValue, int InPlayerDeck, int InPlayerHand, Sprite CardImage, Sprite ThisImage)
    {

        itemName = ItemName;
        itemDescription = ItemDescription;
        itemType = ItemType;
        turnCost = TurnCost;
        cardType = CardType;
        damageValue = DamageValue;
        inPlayerDeck = InPlayerDeck;
        inPlayerHand = InPlayerHand;
        cardImage = CardImage;
        thisImage = ThisImage;
    }
}
