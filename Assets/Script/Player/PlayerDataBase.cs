using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataBase : MonoBehaviour {

    public static List<PlayerData> cardList = new List<PlayerData>();

    public void NewGame()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - StartData");
        Debug.Log("새로시작");
        for (var i = 0; i < data.Count; i++)
        {
            cardList.Add(new PlayerData((string)data[i]["CharacterName"], (int)data[i]["CharacterOpen"], (int)data[i]["BlueSoul"],
                (int)data[i]["RedSoul"], (int)data[i]["Lv"], (int)data[i]["Hp"], (int)data[i]["Shield"],
                (int)data[i]["Exp"], (int)data[i]["StageLevel"]));
        }
    }

    public void LoadGame()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - PlayerData");
        
        Debug.Log("저장 된것 불러옴");
        for (var i = 0; i < data.Count; i++)
        {
            cardList.Add(new PlayerData((string)data[i]["CharacterName"], (int)data[i]["CharacterOpen"], (int)data[i]["BlueSoul"],
                (int)data[i]["RedSoul"], (int)data[i]["Lv"], (int)data[i]["Hp"], (int)data[i]["Shield"],
                (int)data[i]["Exp"], (int)data[i]["StageLevel"]));
        }
        
    }

    public void ResetData()
    {
        cardList.RemoveAll(s => s.characterOpen == 0);
        cardList.RemoveAll(s => s.characterOpen != 0);

        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - StartData");
        Debug.Log("새로시작");
        for (var i = 0; i < data.Count; i++)
        {
            cardList.Add(new PlayerData((string)data[i]["CharacterName"], (int)data[i]["CharacterOpen"], (int)data[i]["BlueSoul"],
                (int)data[i]["RedSoul"], (int)data[i]["Lv"], (int)data[i]["Hp"], (int)data[i]["Shield"],
                (int)data[i]["Exp"], (int)data[i]["StageLevel"]));
        }
    }
}
