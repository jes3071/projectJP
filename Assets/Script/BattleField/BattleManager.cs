using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    public static List<Card> cardList = new List<Card>();

    public Dragable ddd;

    public int tictok = 100;
    public int curTic;
    public int totalTurn;
    public float runTime = .0f;
    public int playerTurnCost = 3; // 받아올 예정
    public int enemyTurnCost = 1;
    public GameObject playerFillCheck;
    public GameObject enemyFillCheck;
    public GameObject playerTurnCheck;

    //public GameObject usingCard;

    // Use this for initialization
    void Start () {


        //GetCardCost(); // 드래그 드랍된 카드의 코스트를 받아오는 함수(만들예정)

        PlayerCostActive(); // 플레이어 카드의 코스트를 받아온 후 비활성화된 코스트 이미지 활성화

        playerFillCheck = GameObject.Find("PlayerTurnCostInner");
        enemyFillCheck = GameObject.Find("EnemyTurnCostInner");

        //usingCard = new Card();

        //cardList[0].itemName = "??";
        //cardList[0].itemDescription = "??";
        //cardList[0].reinforceValue = 0;
        //cardList[0].turnCost = 0;// usingCard.turnCost;
        //cardList[0].cardType = 0;
        //cardList[0].damageValue = 0;

        playerFillCheck.GetComponent<Image>().fillAmount = .0f;
        enemyFillCheck.GetComponent<Image>().fillAmount = .0f;
        //Debug.Log(fillCheck.gameObject);
    }

    public void PlayerCostActive()
    {
        //ddd.gameObject. ==
        if (playerTurnCost == 1)
        {
            playerTurnCheck = GameObject.Find("PlayerBase").transform.Find("PlayerTurnCost" + 0).gameObject;
            playerTurnCheck.SetActive(true);
        }
        else if (playerTurnCost == 2)
        {
            playerTurnCheck = GameObject.Find("PlayerBase").transform.Find("PlayerTurnCost" + 1).gameObject;
            playerTurnCheck.SetActive(true);
        }
        else if (playerTurnCost == 3) {
            playerTurnCheck = GameObject.Find("PlayerBase").transform.Find("PlayerTurnCost" + 2).gameObject;
            playerTurnCheck.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {

        runTime += Time.deltaTime;

        //if (GameOn())
      //  {
            PlayerTurnChecker();
      //  }

    }

    private void PlayerTurnChecker()
    {
        if (playerTurnCost == 1)
        {
            playerFillCheck.GetComponent<Image>().fillAmount += Time.deltaTime / playerTurnCost;
        }
        else if (playerTurnCost == 2)
        {
            playerFillCheck.GetComponent<Image>().fillAmount += Time.deltaTime / playerTurnCost;
        }
        else if (playerTurnCost == 3)
        {
            playerFillCheck.GetComponent<Image>().fillAmount += Time.deltaTime / playerTurnCost;
        }
    }

}
