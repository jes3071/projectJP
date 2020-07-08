using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card {
   // List<int> reinforce = new List<int> ();

	public int id;
    public GameObject cardImage;
    public string cardName;
    public int cost;
    public int power;
    public string cardDesciption;
    public List<int> reinforce = new List<int>(3);

    public Sprite thisImage;

    public Card()
    {


    }

    public Card(int Id, string CardName, int Cost, int Power, string CardDescription, Sprite ThisImage)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDesciption = CardDescription;

        thisImage = ThisImage;

    }
}
