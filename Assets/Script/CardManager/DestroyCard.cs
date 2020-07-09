using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyCard : MonoBehaviour
{

    public GameObject cardObject;

    private void Awake()
    {
        cardObject = GetComponent<GameObject>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        Destroy(cardObject.gameObject);
    }

}
