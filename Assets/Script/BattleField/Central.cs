using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Central : MonoBehaviour
{
    public Transform invisibleCard;

    List<Arranger> arrangers;

    Arranger workingArranger;
    int oriIndex;

    // Start is called before the first frame update
    void Start()
    {
        arrangers = new List<Arranger>();

        var arrs = transform.GetComponentsInChildren<Arranger>();

        for (int i = 0; i < arrs.Length; i++)
        {
            arrangers.Add(arrs[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SwapCards(Transform sour, Transform dest)
    {
        Transform sourParent = sour.parent;
        Transform destParent = dest.parent;

        int sourindext = sour.GetSiblingIndex();
        int destindext = dest.GetSiblingIndex();

        sour.SetParent(destParent);
        sour.SetSiblingIndex(destindext);

        dest.SetParent(sourParent);
        dest.SetSiblingIndex(sourindext);
    }

    void SwapCardsinHierarchy(Transform sour, Transform dest)
    {
        SwapCards(sour, dest);
        arrangers.ForEach(t => t.UpdateChildren());
    }

    bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt, pos);
    }

    void BeginDrag(Transform card)
    {
        //   Debug.Log("BeginDrag : " + card.name);

        workingArranger = arrangers.Find(t => ContainPos(t.transform as RectTransform, card.position));
        oriIndex = card.GetSiblingIndex();

        SwapCardsinHierarchy(invisibleCard, card);
    }
    void Drag(Transform card)
    {
        //  Debug.Log("Drag : " + card.name);

        var whichArrangerCard = arrangers.Find(t => ContainPos(t.transform as RectTransform, card.position));

        if (whichArrangerCard == null)
        {
            //정렬 다시하는 부분
            //bool updateChildren = transform != invisibleCard.parent;

            //invisibleCard.SetParent(transform);

            //if (updateChildren)
            //{
            //    arrangers.ForEach(t => t.UpdateChildren());
            //}
            //Debug.Log("call");
            invisibleCard.SetParent(transform);
            arrangers.ForEach(t => t.UpdateChildren());
        }
        else
        {
            bool insert = invisibleCard.parent == transform;

            if (insert)
            {
                int index = whichArrangerCard.GetIndexByPosition(card);

                invisibleCard.SetParent(whichArrangerCard.transform);
                whichArrangerCard.InsertCard(invisibleCard, index);
            }
            else
            {
                //카드끼리 위치바꾸는 부분
                //int invisibleCardIndex = invisibleCard.GetSiblingIndex();
                //int targetIndex = whichArrangerCard.GetIndexByPosition(card, invisibleCardIndex);

                //if (invisibleCardIndex != targetIndex)
                //{
                //    whichArrangerCard.SwapCard(invisibleCardIndex, targetIndex);
                //}
                Debug.Log(whichArrangerCard.GetIndexByPosition(card, invisibleCard.GetSiblingIndex()));
            }

        }
    }
    void EndDrag(Transform card)
    {
        //  Debug.Log("EndDrag : " + card.name);

        if (invisibleCard.parent == transform)
        {
            card.SetParent(workingArranger.transform);
            workingArranger.InsertCard(card, oriIndex);
            workingArranger = null;
            oriIndex = -1;
            Debug.Log("이건 뭔데");
        }
        else
        {
            SwapCardsinHierarchy(invisibleCard, card);
            Debug.Log(" 그 자리에 있나요");
        }
    }
}
