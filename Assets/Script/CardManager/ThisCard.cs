using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{

    public List<Card> thisCard = new List<Card>();

    public string itemName;
    public string itemDescription;
    public int reinforceValue;
    public int turnCost;
    public int cardType;
    public int damageValue;

    public Text itemNameText;
    public Text itemDescriptionText;
    public Text reinforceValueText;
    public Text turnCostText;
    public Text cardTypeText;
    public Text damageValueText;

    public GameObject Hand;

    public int numberOfCardInDeck;

    //private int i = 0;
    private int rand;



    //public Sprite thisSprite;
    //public Image thatImage;

    //public bool cardBack;
    //public static bool staticCardBack;


    // Use this for initialization
    void Start()
    {
        rand = Random.Range(0, PlayerDeck.playerDeck.Count);
        thisCard[0] = PlayerDeck.playerDeck[rand];
        numberOfCardInDeck = PlayerDeck.deckSize;

        PlayerDeck.playerDeck[rand].inPlayerHand = 1;

        //PlayerDeck.playerDeck.RemoveAt(rand);

        DrawCard();
    }

    public void DrawCard()
    {
        itemName = thisCard[0].itemName;
        itemDescription = thisCard[0].itemDescription;
        reinforceValue = thisCard[0].reinforceValue;
        turnCost = thisCard[0].turnCost;
        cardType = thisCard[0].cardType;
        damageValue = thisCard[0].damageValue;

        itemNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        reinforceValueText.text = "" + reinforceValue;
        turnCostText.text = "" + turnCost;
        cardTypeText.text = "" + cardType;
        damageValueText.text = " " + damageValue;
        
    }
    // Update is called once per frame
    void Update()
    {
        //Hand = GameObject.Find("Hand");
        //if(this.transform.parent == Hand.transform.parent)
        //{
        //    //cardBack = false;
        //}
        


        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.playerDeck[numberOfCardInDeck];
            numberOfCardInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            this.tag = "Untagged";
        }

    }
}
