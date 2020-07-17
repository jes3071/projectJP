using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSystem : MonoBehaviour {

    public GameObject mapPopup;
    public GameObject victoryPopup;

    private void Awake()
    {
        mapPopup = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").gameObject;
        victoryPopup = GameObject.Find("FixedUIHelper").transform.Find("UIBattleVictoryPopup").gameObject;
    }

    // Use this for initialization
    void Start () {
		
	}

    public void VictoryButton()
    {
        mapPopup.SetActive(true);
        victoryPopup.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
