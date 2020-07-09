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

    //public Sprite thisSprite;
    //public Image thatImage;

    //public bool cardBack;
    //public static bool staticCardBack;


    // Use this for initialization
    void Start()
    {
        //for (int i = 0; i < 4; i++)
        //{
        //    int rand = Random.Range(0, CardDataBase.cardList.Count);
        //    thisCard[0] = CardDataBase.cardList[rand];
        //    Draw();
        //    //CardDataBase.cardList.RemoveAt(rand);
        //}
        Draw();

    }

    public void Draw()
    {
        itemName = thisCard[0].itemName;
        itemDescription = thisCard[0].itemDescription;
        reinforceValue = thisCard[0].reinforceValue;
        turnCost = thisCard[0].turnCost;
        cardType = thisCard[0].cardType;
        damageValue = thisCard[0].damageValue;

        //thisSprite = thisCard[0].thisImage;

        itemNameText.text = "" + itemName;
        itemDescriptionText.text = " " + itemDescription;
        reinforceValueText.text = "" + reinforceValue;
        turnCostText.text = "" + turnCost;
        cardTypeText.text = "" + cardType;
        damageValueText.text = " " + damageValue;

        //thatImage.sprite = thisSprite;

        //staticCardBack = cardBack;
    }

    // Update is called once per frame
    void Update()
    {
        //staticCardBack = cardBack;

    }
}
