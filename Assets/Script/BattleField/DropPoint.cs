using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPoint : MonoBehaviour ,IDropHandler{

    public List<Card> uCard = new List<Card>();

    public GameObject cardObject;

    private void Awake()
    {
        cardObject = GetComponent<GameObject>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            Debug.Log("효과를 발동한다!");
            //uCard. = eventData.pointerDrag;

            //eventData.pointerDrag = cardObject;

            Destroy(eventData.pointerDrag);
        }
    }
}
