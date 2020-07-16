using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardDataBase : MonoBehaviour {

    public object _index;

    public static List<EnemyCard> cardList = new List<EnemyCard>();

    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - Monster");

        for (var i = 0; i < data.Count; i++)
        {
            //Debug.Log("index " + (i).ToString() + ": " + data[i]["ItemName"] + " " + data[i]["ItemDescription"] + " " + data[i]["ItemType"] + " " +
            //    data[i]["TurnCost"] + " " + data[i]["CardType"] + " " + data[i]["DamageValue"] + " " + data[i]["InPlayerDeck"]);
            cardList.Add(new EnemyCard((string)data[i]["ItemName"], (string)data[i]["ItemDescription"],
                (int)data[i]["TurnCost"], (int)data[i]["CardType"], (int)data[i]["DamageValue"],(int)data[i]["MonsterType"]));
        }

        //cardList.Add(new Card()
        //cardList.Add(new Card(0, "용사의 검", 3, 3, "Sword", Resources.Load <Sprite>("1")));

    }
}
