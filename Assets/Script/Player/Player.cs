using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public List<PlayerData> playerData = new List<PlayerData>(new PlayerData[1]);
    
    public static int hp;
    
    public static int damageValue;
    public int ackValue;
    public static int shieldValue;

    public string characterName;
    public int characterOpen;
    public static int blueSoul;
    public static int redSoul;
    public int lv;
    public int exp;
    public int stageLevel;

    public Text hpText;
    public Text damageValueText;
    public Text ackValueText;
    public Text shieldValueText;
    public Sprite cardType;
    public Image state;

    public Text blueSoulText;
    public Text redSoulText;
    public Text topHpText;

    // Use this for initialization
    public void Start () {
        //cardObject = GetComponent<GameObject>();
        playerData[0] = PlayerDataBase.cardList[0];

        characterName = playerData[0].characterName;
        characterOpen = playerData[0].characterOpen;
        hp = playerData[0].hp;
        blueSoul = playerData[0].blueSoul;
        redSoul = playerData[0].redSoul;
        lv = playerData[0].lv;
        exp = playerData[0].exp;
        stageLevel = playerData[0].stageLevel;
        //damageValue = 0;
        //ackValue = 0;
        //shieldValue = playerData[0].shield;

        hpText.text = "" + hp;
        //damageValueText.text = "" + damageValue;
        ackValueText.text = "" + ackValue;
        //shieldValueText.text = "" + shieldValue;
        blueSoulText.text = "" + blueSoul;
        redSoulText.text = "" + redSoul;
        state.sprite = Resources.Load<Sprite>("UI/NullImage");
    }

    public void Equip() //장착한거 보여주는 용
    {
        damageValue = DropPoint.uCard.damageValue;
        if (DropPoint.uCard.cardType == 1)
        {
            //리소스에서 공격 이미지 불러오기
            cardType = Resources.Load<Sprite>("UI/PlayerAttackStateIcon");
            state.sprite = cardType;
        }
        else
        {
            //리소스에서 방어 이미지 불러오기
            cardType = Resources.Load<Sprite>("UI/PlayerShieldStateIcon");
            state.sprite = cardType;
        }

        damageValueText.text = "" + damageValue;
    }

    public void UnEquip()
    {
        state.sprite = Resources.Load<Sprite>("UI/NullImage");
        damageValueText.text = "";
    }

    public void Apply() // 실제 공 방에 적용되는 부분
    {
        if (DropPoint.uCard.cardType == 1)
        {
            ackValue = damageValue;
            ackValueText.text = "" + ackValue;
        }
        else
        {
            //shieldValue += damageValue;
            shieldValueText.text = "" + shieldValue;
        }

        hpText.text = "" + hp;
        
    }
	
	// Update is called once per frame
	void Update () {
        hpText.text = "" + hp;
        shieldValueText.text = "" + shieldValue;
        blueSoulText.text = "" + blueSoul;
        redSoulText.text = "" + redSoul;
        topHpText.text = hp + "/10";
    }
}
