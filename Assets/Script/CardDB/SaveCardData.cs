using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class SaveCardData : MonoBehaviour
{
    public void SaveCard()
    {
        using (var writer = new CsvFileWriter("Assets/Resources/GameData/GameData - SaveCardData.csv"))
        {

            List<string> columns = new List<string>() { "Index", "ItemName", "ItemDescription", "ItemType",
        "TurnCost", "CardType", "DamageValue", "InPlayerDeck", "InPlayerHand", "ReinforceValue" };// making Index Row

            writer.WriteRow(columns);

            columns.Clear();

            for (int i = 0; i < 20; i++) 
            {
                columns.Add(CardDataBase.cardList[i].index.ToString()); // Index
                columns.Add(CardDataBase.cardList[i].itemName.ToString()); // ItemName
                columns.Add(CardDataBase.cardList[i].itemDescription.ToString()); // ItemDescription
                columns.Add(CardDataBase.cardList[i].itemType.ToString()); // ItemType
                columns.Add(CardDataBase.cardList[i].turnCost.ToString()); // TurnCost
                columns.Add(CardDataBase.cardList[i].cardType.ToString()); // CardType
                columns.Add(CardDataBase.cardList[i].damageValue.ToString()); // DamageValue
                columns.Add(CardDataBase.cardList[i].inPlayerDeck.ToString()); // InPlayerDeck
                columns.Add(CardDataBase.cardList[i].inPlayerHand.ToString()); // InPlayerHand
                //columns.Add(CardDataBase.cardList[i].rein.ToString()); // ReinforceValue

                writer.WriteRow(columns);
                columns.Clear();
            }

            writer.Dispose();
            //AssetDatabase.Refresh();
        }
    }

    public void DefeatCard()
    {
        CardDataBase.cardList.RemoveAll(s => s.index == 0);
        CardDataBase.cardList.RemoveAll(s => s.index != 0);
        List<Dictionary<string, object>> data = CSVReader.Read("GameData/GameData - Card");

        for (var i = 0; i < data.Count; i++)
        {
            if ((int)data[i]["Index"] < 20)
            {
                CardDataBase.cardList.Add(new Card((int)data[i]["Index"], (string)data[i]["ItemName"], (string)data[i]["ItemDescription"],
                (int)data[i]["ItemType"], (int)data[i]["TurnCost"],
                (int)data[i]["CardType"], (int)data[i]["DamageValue"], (int)data[i]["InPlayerDeck"],
                (int)data[i]["InPlayerHand"], Resources.Load<Sprite>(""), Resources.Load<Sprite>("")));
            }
        }
    }
}
