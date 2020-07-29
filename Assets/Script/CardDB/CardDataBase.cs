using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour {

    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        WarriorCard();
    }

    public void WarriorCard()
    {
        cardList.RemoveAll(s => s.index == 0);
        cardList.RemoveAll(s => s.index != 0);
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - Card");

        for (var i = 0; i < data.Count; i++)
        {
            if((int)data[i]["Index"] < 20)
            {
                cardList.Add(new Card((int)data[i]["Index"], (string)data[i]["ItemName"], (string)data[i]["ItemDescription"],
                (int)data[i]["ItemType"], (int)data[i]["TurnCost"],
                (int)data[i]["CardType"], (int)data[i]["DamageValue"], (int)data[i]["InPlayerDeck"],
                (int)data[i]["InPlayerHand"], Resources.Load<Sprite>(""), Resources.Load<Sprite>("")));
            }
        }
    }

    public void MagicianCard()
    {
        cardList.RemoveAll(s => s.index == 0);
        cardList.RemoveAll(s => s.index != 0);
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - Card");

        for (var i = 20; i < data.Count; i++)
        {
            cardList.Add(new Card((int)data[i]["Index"], (string)data[i]["ItemName"], (string)data[i]["ItemDescription"],
            (int)data[i]["ItemType"], (int)data[i]["TurnCost"],
            (int)data[i]["CardType"], (int)data[i]["DamageValue"], (int)data[i]["InPlayerDeck"],
            (int)data[i]["InPlayerHand"], Resources.Load<Sprite>(""), Resources.Load<Sprite>("")));
        }
    }
}
