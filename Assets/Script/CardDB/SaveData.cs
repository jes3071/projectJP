using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

    

    public Player player;

    public void Save()
    {
        using (var writer = new CsvFileWriter("Assets/Resources/GameData/GameData - PlayerData.csv"))
        {
            //var writer = new CsvFileWriter("Assets/Resources/GameData/GameData - PlayerData.csv");
            List<string> columns = new List<string>() { "CharacterName", "CharacterOpen", "BlueSoul", "RedSoul",
        "Lv", "Hp", "Shield", "Exp", "StageLevel" };// making Index Row

            writer.WriteRow(columns);

            columns.Clear();

            columns.Add(player.characterName + "저장됬나"); // CharacterName

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
        }
    }
}
