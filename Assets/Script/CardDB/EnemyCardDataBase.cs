using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardDataBase : MonoBehaviour {
    
    public static List<EnemyCard> cardList = new List<EnemyCard>();

    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - MonsterCard");

        for (var i = 0; i < data.Count; i++)
        {
            cardList.Add(new EnemyCard((int)data[i]["Index"], (string)data[i]["ItemName"], (string)data[i]["ItemDescription"],
                (int)data[i]["TurnCost"], (int)data[i]["CardType"], (int)data[i]["DamageValue"],(int)data[i]["MonsterType"]));
        }
    }
}
