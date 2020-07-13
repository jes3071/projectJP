using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour {

    public object _index;

    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("GameData - Card");

        for (var i = 0; i < data.Count; i++)
        {
            //Debug.Log("index " + (i).ToString() + ": " + data[i]["ItemName"] + " " + data[i]["ItemDescription"] + " " + data[i]["ReinforceValue"] + " " +
            //    data[i]["TurnCost"] + " " + data[i]["CardType"] + " " + data[i]["DamageValue"] + " " + data[i]["InPlayerDeck"]);
            cardList.Add(new Card((string)data[i]["ItemName"], (string)data[i]["ItemDescription"],
                (int)data[i]["ReinforceValue"], (int)data[i]["TurnCost"],
                (int)data[i]["CardType"], (int)data[i]["DamageValue"], (int)data[i]["InPlayerDeck"],
                (int)data[i]["InPlayerHand"],Resources.Load<Sprite>(""), Resources.Load<Sprite>("") ));
        }

        //cardList.Add(new Card()
        //cardList.Add(new Card(0, "용사의 검", 3, 3, "Sword", Resources.Load <Sprite>("1")));
        
    }
}
