using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataBase : MonoBehaviour
{
    public static List<MonsterData> cardList = new List<MonsterData>();

    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - MonsterData");

        for (var i = 0; i < data.Count; i++)
        {
            cardList.Add(new MonsterData((string)data[i]["MonsterName"], (int)data[i]["MonsterPrefabID"], (int)data[i]["StageLevel"],
                (string)data[i]["MonsterDescription"], (int)data[i]["Hp"], (int)data[i]["Shield"], (int)data[i]["BlueSoul"],
                (int)data[i]["MaxRedSoul"], (int)data[i]["Exp"]));
        }
    }
}
