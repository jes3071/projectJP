using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataBase : MonoBehaviour {

    public static List<PlayerData> cardList = new List<PlayerData>();

    public static string strFile = "GameData/GameData - PlayerData";
    FileInfo fileInfo = new FileInfo(strFile);

    void Awake()
    {
        if (fileInfo.Exists)
        {
            List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - PlayerData");

            for (var i = 0; i < data.Count; i++)
            {
                cardList.Add(new PlayerData((string)data[i]["CharacterName"], (int)data[i]["CharacterOpen"], (int)data[i]["BlueSoul"],
                    (int)data[i]["RedSoul"], (int)data[i]["Lv"], (int)data[i]["Hp"], (int)data[i]["Shield"],
                    (int)data[i]["Exp"], (int)data[i]["StageLevel"]));
            }
        }
        else
        {
            List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - StartData");

            for (var i = 0; i < data.Count; i++)
            {
                cardList.Add(new PlayerData((string)data[i]["CharacterName"], (int)data[i]["CharacterOpen"], (int)data[i]["BlueSoul"],
                    (int)data[i]["RedSoul"], (int)data[i]["Lv"], (int)data[i]["Hp"], (int)data[i]["Shield"],
                    (int)data[i]["Exp"], (int)data[i]["StageLevel"]));
            }
        }

    }
}
