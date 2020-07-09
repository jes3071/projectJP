using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    //public card
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject cardObject;

    //public Card aaa;

    public bool Flag = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        cardObject = GetComponent<GameObject>();
        //aaa = GetComponent<Card>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;

        //workingArranger = arrangers.Find(t => ContainPos(t.transform as RectTransform, eventData.position));
        //rectTransform.position.x;
        //rectTransform.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver);
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        //transform.position = eventData.position;
        rectTransform.anchoredPosition += eventData.delta;
        //rectTransform.BroadcastMessage("Drag", transform, SendMessageOptions.DontRequireReceiver);
        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = eventData.delta;
        //Debug.Log(eventData.position);
        if (eventData.position.x <= 700 && eventData.position.x >= 500 &&
            eventData.position.y >= 400 && eventData.position.y <= 800)
        {
            //aaa.turnCost = gameObject.
            Destroy(gameObject);
        }
        //Destroy(gameObject);
        //rectTransform.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
        //throw new System.NotImplementedException();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //gameObject.SetActive(false);
        //Destroy(gameObject);
        //Debug.Log("OnDrop");
        throw new System.NotImplementedException();
    }

}
