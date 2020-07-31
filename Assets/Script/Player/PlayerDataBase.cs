using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataBase : MonoBehaviour {

    public static List<PlayerData> cardList = new List<PlayerData>();

    public SaveData saveData;

    public int loadCheck;
    static string strFile = "Assets/Resources/GameData/GameData - PlayerData.csv";
    
    FileInfo fileInfo = new FileInfo(strFile);

    public void CheckLoadData()
    {
        if (fileInfo.Exists)
        {
            Debug.Log("존재");
            loadCheck = 1;
        }
        else
        {
            Debug.Log("미존재");
            loadCheck = 0;
        }
    }

    public void NewGame()
    {
        cardList.RemoveAll(s => s.characterOpen == 0);
        cardList.RemoveAll(s => s.characterOpen != 0);
        //List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - StartData");
        
        if(Player.redSoul != 0)
        {
            saveData.DefeatReset();
            List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - StartData");
            for (var i = 0; i < data.Count; i++)
            {
                cardList.Add(new PlayerData((string)data[i]["CharacterName"], (int)data[i]["CharacterOpen"], (int)data[i]["BlueSoul"],
                    Player.redSoul, (int)data[i]["Lv"], (int)data[i]["Hp"], (int)data[i]["Shield"],
                    (int)data[i]["Exp"], (int)data[i]["StageLevel"]));
            }
            saveData.DefeatReset();
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
            Debug.Log("새로시작");
        }
        //saveData.DefeatReset();
    }

    public void LoadGame()
    {
        cardList.RemoveAll(s => s.characterOpen == 0);
        cardList.RemoveAll(s => s.characterOpen != 0);
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - PlayerData");
        
        Debug.Log("저장 된것 불러옴");
        for (var i = 0; i < data.Count; i++)
        {
            cardList.Add(new PlayerData((string)data[i]["CharacterName"], (int)data[i]["CharacterOpen"], (int)data[i]["BlueSoul"],
                (int)data[i]["RedSoul"], (int)data[i]["Lv"], (int)data[i]["Hp"], (int)data[i]["Shield"],
                (int)data[i]["Exp"], (int)data[i]["StageLevel"]));

            Debug.Log((string)data[i]["CharacterName"] + (int)data[i]["CharacterOpen"]+ (int)data[i]["BlueSoul"]+
                (int)data[i]["RedSoul"]+ (int)data[i]["Lv"]+ (int)data[i]["Hp"]+ (int)data[i]["Shield"]+
                (int)data[i]["Exp"]+ (int)data[i]["StageLevel"]);
        }
    }

    public void ResetData()
    {
        cardList.RemoveAll(s => s.characterOpen == 0);
        cardList.RemoveAll(s => s.characterOpen != 0);

        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - StartData");
        Debug.Log("리셋데이터");
        for (var i = 0; i < data.Count; i++)
        {
            cardList.Add(new PlayerData((string)data[i]["CharacterName"], (int)data[i]["CharacterOpen"], (int)data[i]["BlueSoul"],
                Player.redSoul, (int)data[i]["Lv"], (int)data[i]["Hp"], (int)data[i]["Shield"],
                (int)data[i]["Exp"], (int)data[i]["StageLevel"]));
        }
    }
}
