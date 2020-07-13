using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int level;
    public int hp;
    public int ackValue;
    public int shieldValue;

    public Text hpText;
    public Text ackValueText;
    public Text shieldValueText;

   // public GameObject cardObject;
    public ThisCard card;


    // Use this for initialization
    void Start () {
        //cardObject = GetComponent<GameObject>();
        hp = 10;
        ackValue = 0;
        shieldValue = 0;

        hpText.text = "" + hp;
        ackValueText.text = "" + ackValue;
        shieldValueText.text = "" + shieldValue;
    }

    public void Equip()
    {
        ackValue = 0;
        shieldValue = 0;


        if (DropPoint.uCard.cardType == 1)
        {
            ackValue = DropPoint.uCard.damageValue;
        }
        else
        {
            shieldValue = DropPoint.uCard.damageValue;
        }

        hpText.text = "" + hp;
        ackValueText.text = "" + ackValue;
        shieldValueText.text = "" + shieldValue;
    }
	
	// Update is called once per frame
	void Update () {
		if(DropPoint.uCard != null)
        {
            Equip();
        }
	}
}
