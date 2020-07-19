﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSystem : MonoBehaviour {

    public GameObject mapPopup;
    public GameObject victoryPopup;
    public GameObject fireImage;
    public GameObject mapClick;
    public GameObject mapSelect;
    public GameObject buttonOnOff;

    public bool battleMap = false;

    private void Awake()
    {
        mapPopup = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").gameObject;
        victoryPopup = GameObject.Find("FixedUIHelper").transform.Find("UIBattleVictoryPopup").gameObject;
        InitilaizeButton();
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

    public void InitilaizeButton()
    {

        buttonOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").Find("Area" + 0).Find("Position" + 0).gameObject;
        buttonOnOff.GetComponent<Button>().interactable = false;
        buttonOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").Find("Area" + 1).Find("Position" + 0).gameObject;
        buttonOnOff.GetComponent<Button>().interactable = false;
        buttonOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").Find("Area" + 1).Find("Position" + 1).gameObject;
        buttonOnOff.GetComponent<Button>().interactable = false;
        buttonOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").Find("Area" + 2).Find("Position" + 0).gameObject;
        buttonOnOff.GetComponent<Button>().interactable = false;
        buttonOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").Find("Area" + 2).Find("Position" + 1).gameObject;
        buttonOnOff.GetComponent<Button>().interactable = false;
        buttonOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").Find("Area" + 2).Find("Position" + 2).gameObject;
        buttonOnOff.GetComponent<Button>().interactable = false;
        buttonOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").Find("Area" + 3).Find("Position" + 0).gameObject;
        buttonOnOff.GetComponent<Button>().interactable = false;
        buttonOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").Find("Area" + 3).Find("Position" + 1).gameObject;
        buttonOnOff.GetComponent<Button>().interactable = false;
        buttonOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").Find("Area" + 4).Find("Position" + 0).gameObject;
        buttonOnOff.GetComponent<Button>().interactable = false;
        
    }

    public void MapMove()
    {
        if (BattleManager.stageLevel == 0)
        {
            mapClick = GameObject.Find("Area" + 1).transform.Find("Position" + 0).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
            mapSelect = GameObject.Find("Area" + 1).transform.Find("Position" + 0).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(true);
            mapClick = GameObject.Find("Area" + 1).transform.Find("Position" + 1).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
            mapSelect = GameObject.Find("Area" + 1).transform.Find("Position" + 1).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(true);
        }
        if(BattleManager.stageLevel == 1)
        {
            mapClick = GameObject.Find("Area" + 1).transform.Find("Position" + 0).gameObject;
            mapClick.GetComponent<Button>().interactable = false;
            mapSelect = GameObject.Find("Area" + 1).transform.Find("Position" + 0).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(false);
            mapClick = GameObject.Find("Area" + 1).transform.Find("Position" + 1).gameObject;
            mapClick.GetComponent<Button>().interactable = false;
            mapSelect = GameObject.Find("Area" + 1).transform.Find("Position" + 1).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(false);

            mapClick = GameObject.Find("Area" + 2).transform.Find("Position" + 0).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
            mapSelect = GameObject.Find("Area" + 2).transform.Find("Position" + 0).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(true);
            mapClick = GameObject.Find("Area" + 2).transform.Find("Position" + 1).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
            mapSelect = GameObject.Find("Area" + 2).transform.Find("Position" + 1).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(true);
            mapClick = GameObject.Find("Area" + 2).transform.Find("Position" + 2).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
            mapSelect = GameObject.Find("Area" + 2).transform.Find("Position" + 2).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(true);
        }
        if (BattleManager.stageLevel == 2)
        {
            mapClick = GameObject.Find("Area" + 2).transform.Find("Position" + 0).gameObject;
            mapClick.GetComponent<Button>().interactable = false;
            mapSelect = GameObject.Find("Area" + 2).transform.Find("Position" + 0).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(false);
            mapClick = GameObject.Find("Area" + 2).transform.Find("Position" + 1).gameObject;
            mapClick.GetComponent<Button>().interactable = false;
            mapSelect = GameObject.Find("Area" + 2).transform.Find("Position" + 1).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(false);
            mapClick = GameObject.Find("Area" + 2).transform.Find("Position" + 2).gameObject;
            mapClick.GetComponent<Button>().interactable = false;
            mapSelect = GameObject.Find("Area" + 2).transform.Find("Position" + 2).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(false);

            mapClick = GameObject.Find("Area" + 3).transform.Find("Position" + 0).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
            mapSelect = GameObject.Find("Area" + 3).transform.Find("Position" + 0).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(true);
            mapClick = GameObject.Find("Area" + 3).transform.Find("Position" + 1).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
            mapSelect = GameObject.Find("Area" + 3).transform.Find("Position" + 1).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(true);
        }
        if(BattleManager.stageLevel == 3)
        {
            mapClick = GameObject.Find("Area" + 3).transform.Find("Position" + 0).gameObject;
            mapClick.GetComponent<Button>().interactable = false;
            mapSelect = GameObject.Find("Area" + 3).transform.Find("Position" + 0).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(false);
            mapClick = GameObject.Find("Area" + 3).transform.Find("Position" + 1).gameObject;
            mapClick.GetComponent<Button>().interactable = false;
            mapSelect = GameObject.Find("Area" + 3).transform.Find("Position" + 1).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(false);

            mapClick = GameObject.Find("Area" + 4).transform.Find("Position" + 0).gameObject;
            mapClick.GetComponent<Button>().interactable = true;
            mapSelect = GameObject.Find("Area" + 4).transform.Find("Position" + 0).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(true);
        }
    }

    public void GoBattleScene()
    {
        battleMap = true;
        mapPopup.SetActive(false);
    }
}
