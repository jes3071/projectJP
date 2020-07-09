using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPoint : MonoBehaviour ,IDropHandler{

    public Card uCard;

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

            //eventData.gameObject;

            //Dragable.
            //Destroy(gameObject);
            //Debug.Log(eventData);

            //gameObject.SetActive(false);
            //eventData.Destroy();
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
