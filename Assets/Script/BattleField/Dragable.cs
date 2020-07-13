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
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = eventData.delta;

    }

    public void OnDrop(PointerEventData eventData)
    {

        throw new System.NotImplementedException();
    }

}
