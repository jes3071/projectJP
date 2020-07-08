using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public float ori_x;
    public float ori_y;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt, pos);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;

        //workingArranger = arrangers.Find(t => ContainPos(t.transform as RectTransform, eventData.position));
        //rectTransform.position.x;
        ori_x = eventData.position.x;
        ori_y = eventData.position.y;
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
        if (eventData.pointerDrag != null)
            rectTransform.anchoredPosition = eventData.delta;
        //rectTransform.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
        //throw new System.NotImplementedException();
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

}
