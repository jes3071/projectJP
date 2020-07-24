using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataBase : MonoBehaviour {

    public static List<PlayerData> cardList = new List<PlayerData>();

    

    void Awake()
    {
        
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - PlayerData");

        //if (data[0]["StageLevel"].Equals(-1))
        //{
        //    for (var i = 0; i < data.Count; i++)
        //    {
        //        cardList.Add(new PlayerData((string)data[i]["CharacterName"], (int)data[i]["CharacterOpen"], (int)data[i]["BlueSoul"],
        //            (int)data[i]["RedSoul"], (int)data[i]["Lv"], (int)data[i]["Hp"], (int)data[i]["Shield"],
        //            (int)data[i]["Exp"], (int)data[i]["StageLevel"]));
        //    }
        //}
        //else
        {
            //data.Clear();
            List<Dictionary<string, object>> startData = CSVReader.Read("GameData/GameData - StartData");

            for (var i = 0; i < startData.Count; i++)
            {
                cardList.Add(new PlayerData((string)startData[i]["CharacterName"], (int)startData[i]["CharacterOpen"], (int)startData[i]["BlueSoul"],
                    (int)startData[i]["RedSoul"], (int)startData[i]["Lv"], (int)startData[i]["Hp"], (int)startData[i]["Shield"],
                    (int)startData[i]["Exp"], (int)startData[i]["StageLevel"]));
            }
        }

            
       
            //List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - StartData");

            
        

    }
}
