using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSystem : MonoBehaviour {

    public GameObject characterSelect;
    public GameObject mapPopup;
    public GameObject victoryPopup;
    public GameObject defeatPopup;
    public GameObject fireImage;
    public GameObject mapClick;
    public GameObject mapSelect;
    public GameObject buttonOnOff;
    public GameObject toStart;
    public GameObject battleOnOff;

    public SaveData saveData;
    public PlayerDataBase playerDataBase;

    public bool battleMap = false;

    private void Awake()
    {
        characterSelect = GameObject.Find("FixedUIHelper").transform.Find("UILoobyCharacterSelectPopup").gameObject;
        mapPopup = GameObject.Find("FixedUIHelper").transform.Find("UIMapPopup").gameObject;
        victoryPopup = GameObject.Find("FixedUIHelper").transform.Find("UIBattleVictoryPopup").gameObject;
        defeatPopup = GameObject.Find("FixedUIHelper").transform.Find("UIBattleDefeatPopup").gameObject;
        toStart = GameObject.Find("UILobbyStartPopup").gameObject;
        InitilaizeButton();
    }

    // Use this for initialization
    void Start () {
        

    }

    public void TouchToStart()
    {
        characterSelect.SetActive(true);
        toStart.SetActive(false);
    }

    public void SelectCharacter()
    {
        playerDataBase.NewGame();
        mapPopup.SetActive(true);
        characterSelect.SetActive(false);
        BattleManager.stageLevel = PlayerDataBase.cardList[0].stageLevel;
        SeeMapRoad();
        MapMove();
        //if()
        //mapClick = GameObject.Find("Area" + 0).transform.Find("Position" + 0).gameObject;
        //mapClick.GetComponent<Button>().interactable = true;
        //mapSelect = GameObject.Find("Area" + 0).transform.Find("Position" + 0).transform.Find("SelectActive").gameObject;
        //mapSelect.SetActive(true);
        battleOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIBattleTop").gameObject;
        battleOnOff.SetActive(true);

        toStart.SetActive(false);
    }

    public void TouchToExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void VictoryButton()
    {
        mapPopup.SetActive(true);
        BattleManager.stageLevel++;
        battleMap = false;
        SeeMapRoad();
        MapMove();
        victoryPopup.SetActive(false);
        battleOnOff = GameObject.Find("FixedUIHelper/UIBattleField").gameObject;
        battleOnOff.SetActive(false);
        battleOnOff = GameObject.Find("FixedUIHelper/UIBattlePlayerHand").gameObject;
        battleOnOff.SetActive(false);
        battleOnOff = GameObject.Find("FixedUIHelper/UIBattlePlayerDeck").gameObject;
        battleOnOff.SetActive(false);
        battleOnOff = GameObject.Find("System").transform.Find("BattleManger").gameObject;
        battleOnOff.SetActive(false);
        SaveGameData();
    }

    public void SaveGameData()
    {
        saveData.Save();
    }

    public void GoToStartScene()
    {
        battleMap = false;
        toStart.SetActive(true);
        defeatPopup.SetActive(false);
        battleOnOff = GameObject.Find("FixedUIHelper/UIBattleField").gameObject;
        battleOnOff.SetActive(false);
        battleOnOff = GameObject.Find("FixedUIHelper/UIBattlePlayerHand").gameObject;
        battleOnOff.SetActive(false);
        battleOnOff = GameObject.Find("FixedUIHelper/UIBattlePlayerDeck").gameObject;
        battleOnOff.SetActive(false);
        battleOnOff = GameObject.Find("System").transform.Find("BattleManger").gameObject;
        battleOnOff.SetActive(false);
        saveData.DefeatReset();
        Debug.Log("리셋됨");
    }

    public void SeeMapRoad()
    {
        for(int i = 0; i < 5; i++)
        {
            if (BattleManager.stageLevel >= i)
            {
                fireImage = GameObject.Find("Area" + i).transform.Find("Artefact").transform.Find("FireImage").gameObject;
                fireImage.SetActive(true);
                //break;
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
            mapClick = GameObject.Find("Area" + 0).transform.Find("Position" + 0).gameObject;
            mapClick.GetComponent<Button>().interactable = false;
            mapSelect = GameObject.Find("Area" + 0).transform.Find("Position" + 0).transform.Find("SelectActive").gameObject;
            mapSelect.SetActive(false);

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
        battleOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIBattleField").gameObject;
        battleOnOff.SetActive(true);
        battleOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIBattlePlayerHand").gameObject;
        battleOnOff.SetActive(true);
        battleOnOff = GameObject.Find("FixedUIHelper").transform.Find("UIBattlePlayerDeck").gameObject;
        battleOnOff.SetActive(true);
        battleOnOff = GameObject.Find("System").transform.Find("BattleManger").gameObject;
        battleOnOff.SetActive(true);
    }
}