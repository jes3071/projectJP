using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour {

    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    public bool cardBack;
    public static bool staticCardBack;

    
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, CardDataBase.cardList.Count);
            thisCard[0] = CardDataBase.cardList[rand];
            Draw();
            //CardDataBase.cardList.RemoveAt(rand);
        }
        
	}

    public void Draw()
    {
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardDescription = thisCard[0].cardDesciption;

        thisSprite = thisCard[0].thisImage;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        powerText.text = "" + power;
        descriptionText.text = " " + cardDescription;

        thatImage.sprite = thisSprite;

        staticCardBack = cardBack;
    }

    // Update is called once per frame
    void Update () {
        staticCardBack = cardBack;

    }
}
