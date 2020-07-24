using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{

    public List<Card> thisCard = new List<Card>();

    public int index;
    public string itemName;
    public string itemDescription;
    public int itemType;
    public int turnCost;
    public int cardType;
    public int damageValue;
    public int inPlayerHand;

    public Text itemNameText;
    public Text itemDescriptionText;
    //public Text ItemTypeText;
    public Text turnCostText;
    //public Text cardTypeText;
    public Text damageValueText;

    public GameObject Hand;

    public GameObject Deck;

    public int numberOfCardInDeck;

    //private int i = 0;
    private int rand;
    public static int _index = 0;
    public int j = 0;

    public Sprite cardSprite;
    public Image cardImage;

    public Sprite thisSprite;
    public Image thisimage;

    //public bool cardBack;
    //public static bool staticCardBack;

    private void Awake()
    {
        Deck = GameObject.Find("FixedUIHelper").transform.Find("UIBattlePlayerDeckPopup").gameObject;
    }

    // Use this for initialization
    void Start()
    {
        if (Deck.activeSelf == false)
        {
            //IndexDeckOpen();
            rand = Random.Range(0, PlayerDeck.playerDeck.Count);

            while (PlayerDeck.playerDeck[rand].inPlayerHand == 1)
                rand = Random.Range(0, PlayerDeck.playerDeck.Count);

            thisCard[0] = PlayerDeck.playerDeck[rand];
            numberOfCardInDeck = PlayerDeck.deckSize;

            PlayerDeck.playerDeck[rand].inPlayerHand = 1;
        }
        else if(Deck.activeSelf == true)
        {
            Bubble_sort(PlayerDeck.playerDeck, 6);
            IndexDeckOpen();
        }
        DrawCard();
    }

    void Bubble_sort(List<Card> index, int n)
    {
        int i, j;
        Card temp;

        for (i = n - 1; i > 0; i--)
        {
            // 0 ~ (i-1)까지 반복
            for (j = 0; j < i; j++)
            {
                // j번째와 j+1번째의 요소가 크기 순이 아니면 교환
                if (index[j].index > index[j + 1].index)
                {
                    temp = index[j];
                    index[j] = index[j + 1];
                    index[j + 1] = temp;
                }
            }
        }
    }

    public void IndexDeckOpen()
    {
        //while (PlayerDeck.playerDeck[_index].inPlayerHand != 1)
        //{
        //        //Debug.Log(PlayerDeck.playerDeck[_index].index);
        thisCard[0] = PlayerDeck.playerDeck[_index++];
        //        //_index++;
        //        //Debug.Log(thisCard[0].index);
        //        break;

        //}
        //Debug.Log(_index);
        if (_index >= 6)
        {
            _index = 0;
        }
    }

    public void DrawCard()
    {
        index = thisCard[0].index;
        itemName = thisCard[0].itemName;
        itemDescription = thisCard[0].itemDescription;
        itemType = thisCard[0].itemType;
        turnCost = thisCard[0].turnCost;
        cardType = thisCard[0].cardType;
        damageValue = thisCard[0].damageValue;
        inPlayerHand = thisCard[0].inPlayerHand;

        if (cardType == 1) //공
        {
            if (itemType == 1) //숏소드
            {
                thisSprite = Resources.Load<Sprite>("UI/Battle/WeaponCardBase0");
            }
            else if (itemType == 2) //롱소드
            {
                thisSprite = Resources.Load<Sprite>("UI/Battle/WeaponCardBase1");
            }
            else if (itemType == 3) //대검류
            {
                thisSprite = Resources.Load<Sprite>("UI/Battle/WeaponCardBase2");
            }

            for(int i = 0; i < 10; i++)
            {
                if(index == i)
                {
                    cardSprite = Resources.Load<Sprite>("UI/Battle/Item/WeaponCardItemImage" + i);
                    break;
                }
            }
        }

        if (cardType == 2) //방
        {
            if (itemType == 1) //나무방패
            {
                thisSprite = Resources.Load<Sprite>("UI/Battle/ShieldCardBase0");
            }
            else if (itemType == 2) //구리방패
            {
                thisSprite = Resources.Load<Sprite>("UI/Battle/ShieldCardBase1");
            }
            else if (itemType == 3) //철,금방패
            {
                thisSprite = Resources.Load<Sprite>("UI/Battle/ShieldCardBase2");
            }
            for (int i = 0; i < 10; i++)
            {
                if (index == (i+10))
                {
                    cardSprite = Resources.Load<Sprite>("UI/Battle/Item/ShieldCardItemImage" + i);
                    break;
                }
            }
        }

        //cardSprite = thisCard[0].cardImage; //검 방패
        //thisSprite = thisCard[0].thisImage; //겉 테두리, 공방

        //thisSprite = GameObject.Find("PlayerTurnCostInner");
        //thisSprite = ;
        itemNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        //ItemTypeText.text = "" + ItemType;
        turnCostText.text = "" + turnCost;
        //cardTypeText.text = "" + cardType;
        damageValueText.text = "" + damageValue;

        cardImage.sprite = cardSprite;
        thisimage.sprite = thisSprite;
        cardImage.SetNativeSize();
        thisimage.SetNativeSize();

    }
    // Update is called once per frame
    void Update()
    {
        //Hand = GameObject.Find("Hand");
        //if(this.transform.parent == Hand.transform.parent)
        //{
        //    //cardBack = false;
        //}
        //DrawCard();


        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.playerDeck[numberOfCardInDeck];
            numberOfCardInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            this.tag = "Untagged";
        }

    }
}
