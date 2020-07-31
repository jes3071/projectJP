using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveData : MonoBehaviour {


    public PlayerDataBase playerDataBase;
    public Player player;

    public void Save()
    {
        using (var writer = new CsvFileWriter("Assets/Resources/GameData/GameData - PlayerData.csv"))
        {
                
            List<string> columns = new List<string>() { "CharacterName", "CharacterOpen", "BlueSoul", "RedSoul",
        "Lv", "Hp", "Shield", "Exp", "StageLevel" };// making Index Row
            
            writer.WriteRow(columns);

            columns.Clear();

            columns.Add(player.characterName); // CharacterName

            columns.Add(player.characterOpen.ToString()); // CharacterOpen

            columns.Add(Player.blueSoul.ToString()); // BlueSoul

            columns.Add(Player.redSoul.ToString()); // RedSoul

            columns.Add(player.lv.ToString()); // Lv

            columns.Add(Player.hp.ToString()); // Hp

            columns.Add(Player.shieldValue.ToString()); // Shield

            columns.Add(player.exp.ToString()); // Exp

            columns.Add(BattleManager.stageLevel.ToString()); // StageLevel

            writer.WriteRow(columns);

            columns.Clear();

            writer.Dispose();
            AssetDatabase.Refresh();
        }
    }

    public void DefeatReset()
    {
        using (var writer = new CsvFileWriter("Assets/Resources/GameData/GameData - PlayerData.csv"))
        {

            List<string> columns = new List<string>() { "CharacterName", "CharacterOpen", "BlueSoul", "RedSoul",
        "Lv", "Hp", "Shield", "Exp", "StageLevel" };// making Index Row

            writer.WriteRow(columns);

            columns.Clear();

            playerDataBase.ResetData();

            columns.Add(PlayerDataBase.cardList[0].characterName); // CharacterName

            columns.Add(PlayerDataBase.cardList[0].characterOpen.ToString()); // CharacterOpen

            columns.Add(PlayerDataBase.cardList[0].blueSoul.ToString()); // BlueSoul

            columns.Add(Player.redSoul.ToString()); // RedSoul

            columns.Add(PlayerDataBase.cardList[0].lv.ToString()); // Lv

            columns.Add(PlayerDataBase.cardList[0].hp.ToString()); // Hp

            columns.Add(PlayerDataBase.cardList[0].shield.ToString()); // Shield

            columns.Add(PlayerDataBase.cardList[0].exp.ToString()); // Exp

            columns.Add(PlayerDataBase.cardList[0].stageLevel.ToString()); // StageLevel

            writer.WriteRow(columns);

            columns.Clear();

            writer.Dispose();

            

            AssetDatabase.Refresh();
        }
    }
}
