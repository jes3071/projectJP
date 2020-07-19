using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPoint : MonoBehaviour ,IDropHandler{

    public List<Card> dropCard = new List<Card>(new Card[1]);

    public static ThisCard uCard;

    public static GameObject cardObject;

    public Player equipCard;

    private void Awake()
    {
        //cardObject = GetComponent<GameObject>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            //Debug.Log("카드 드랍됨");
            cardObject = eventData.pointerDrag;
            uCard = cardObject.GetComponent<ThisCard>();

            dropCard[0].index = uCard.index;
            dropCard[0].itemName = uCard.itemName;
            dropCard[0].itemDescription = uCard.itemDescription;
            dropCard[0].itemType = uCard.itemType;
            dropCard[0].turnCost = uCard.turnCost;
            dropCard[0].cardType = uCard.cardType;
            dropCard[0].damageValue = uCard.damageValue;

            //Debug.Log(uCard.itemName);
            uCard.inPlayerHand = 0;

            eventData.pointerDrag.SetActive(false);

            PlayerDeck.playerDeck.Add(new Card(dropCard[0].index, dropCard[0].itemName, dropCard[0].itemDescription,
               dropCard[0].itemType, dropCard[0].turnCost, dropCard[0].cardType, dropCard[0].damageValue,
               1, 0, null, null));
            //Debug.Log("카드 덱에 추가됨");
            //uCard = null;

            equipCard.Equip(); // 장비 장착

            BattleManager.turnOnOff = true;

            //CardSpawn.curCount--;
        }
    }
}
