using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int level;
    public static int hp;

    public static int damageValue;

    public Text hpText;
    //public Text damageValueText;

   // public GameObject cardObject;
    public ThisCard card;


    // Use this for initialization
    void Start () {
        //cardObject = GetComponent<GameObject>();
        hp = 10;
        damageValue = 0;

        hpText.text = "" + hp;
        //damageValueText.text = "" + damageValue;
    }

    public void Equip()
    {
        damageValue = 0;

        damageValue = DropPoint.uCard.damageValue;
        if (DropPoint.uCard.cardType == 1)
        {
            //리소스에서 공격 이미지 불러오기
        }
        else
        {
            //리소스에서 방어 이미지 불러오기
        }

        //hpText.text = "" + hp;
        //ackValueText.text = "" + ackValue;
        //shieldValueText.text = "" + shieldValue;
    }
	
	// Update is called once per frame
	void Update () {
		if(DropPoint.uCard != null)
        {
            Equip();
        }
	}
}
