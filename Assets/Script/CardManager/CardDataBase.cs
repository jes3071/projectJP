using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour {

    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "용사의 검", 3, 3, "Sword", Resources.Load <Sprite>("1")));
        cardList.Add(new Card(1, "이순신의 투구", 1, 2, "Helmet", Resources.Load<Sprite>("2")));
        cardList.Add(new Card(2, "엘프의 활", 2, 2, "Bow", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(3, "성직자의 메이스", 1, 1, "Prist", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(4, "드워프의 망치", 2, 2, "Hammer", Resources.Load<Sprite>("1")));
    }
}
