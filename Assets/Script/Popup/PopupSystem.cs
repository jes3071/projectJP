using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSystem : MonoBehaviour {

    public GameObject mapPopup;
    public GameObject victoryPopup;
    public GameObject fireImage;
    public GameObject mapClick;

    public bool battleMap = false;

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
        battleMap = false;
        SeeMapRoad();
        MapMove();
        victoryPopup.SetActive(false);
    }

    public void SeeMapRoad()
    {
        for(int i = 0; i < 5; i++)
        {
            if (BattleManager.stageLevel == i)
            {
                fireImage = GameObject.Find("Area" + i).transform.Find("Artefact").transform.Find("FireImage").gameObject;
                fireImage.SetActive(true);
                break;
            }
        }
    }

    public void MapMove()
    {
        if (BattleManager.stageLevel == 0)
        {
            mapClick = GameObject.Find("Area" + 1).transform.Find("Position" + 0).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
            mapClick = GameObject.Find("Area" + 1).transform.Find("Position" + 1).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
        }
    }

    public void GoBattleScene()
    {
        battleMap = true;
        mapPopup.SetActive(false);
    }
}
