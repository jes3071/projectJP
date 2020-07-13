using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    public List<Card> playerCardInfo = new List<Card>(new Card[1]);

    public int tictok = 100;
    public int curTic;
    public int totalTurn;

    public static bool turnOnOff = false;

    public float runTime = .0f;
    public float turnTime = .0f;
    public int playerTurnCost = 3; // 받아올 예정
    public int enemyTurnCost = 1;
    public GameObject playerFillCheck;
    public GameObject enemyFillCheck;
    public GameObject playerTurnCheck;
    public GameObject enemyTurnCheck;

    public GameObject CardTouchBlock;

    public Text TurnText;

    //public GameObject usingCard;

    public void Awake()
    {
        CardTouchBlock = GameObject.Find("CardTouchBlock");
    }

    // Use this for initialization
    void Start () {


        CardTouchBlock.GetComponent<Image>().raycastTarget = false;

        if (DropPoint.uCard != null)
        {
            playerCardInfo[0].itemName = DropPoint.uCard.itemName;
            playerCardInfo[0].itemDescription = DropPoint.uCard.itemDescription;
            playerCardInfo[0].reinforceValue = DropPoint.uCard.reinforceValue;
            playerCardInfo[0].turnCost = DropPoint.uCard.turnCost;
            playerCardInfo[0].cardType = DropPoint.uCard.cardType;
            playerCardInfo[0].damageValue = DropPoint.uCard.damageValue;
            playerTurnCost = playerCardInfo[0].turnCost;
        }

            TurnText.text = "0 Turn";
        //GetCardCost(); // 드래그 드랍된 카드의 코스트를 받아오는 함수(만들예정)

        //PlayerCostActive(); // 플레이어 카드의 코스트를 받아온 후 비활성화된 코스트 이미지 활성화
        //EnemyCostActive();

        //playerFillCheck = GameObject.Find("PlayerTurnCostInner");
        //enemyFillCheck = GameObject.Find("EnemyTurnCostInner");
        
        //playerFillCheck.GetComponent<Image>().fillAmount = .0f;
        //enemyFillCheck.GetComponent<Image>().fillAmount = .0f;
        //Debug.Log(fillCheck.gameObject);
    }

    public void PlayerCostActive()
    {
        //ddd.gameObject. ==
        if(playerTurnCheck != null)
        {
            playerTurnCheck.SetActive(false); // 그 전에 켜진 코스트 이미지는 꺼준다?
        }

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

        playerFillCheck = GameObject.Find("PlayerTurnCostInner");
        playerFillCheck.GetComponent<Image>().fillAmount = .0f;
    }

    public void EnemyCostActive()
    {
        //ddd.gameObject. ==
        if (enemyTurnCheck != null)
        {
            enemyTurnCheck.SetActive(false); // 그 전에 켜진 코스트 이미지는 꺼준다?
        }

        if (enemyTurnCost == 1)
        {
            enemyTurnCheck = GameObject.Find("EnemyBase").transform.Find("EnemyTurnCost" + 0).gameObject;
            enemyTurnCheck.SetActive(true);
        }
        else if (enemyTurnCost == 2)
        {
            enemyTurnCheck = GameObject.Find("EnemyBase").transform.Find("EnemyTurnCost" + 1).gameObject;
            enemyTurnCheck.SetActive(true);
        }
        else if (enemyTurnCost == 3)
        {
            enemyTurnCheck = GameObject.Find("EnemyBase").transform.Find("EnemyTurnCost" + 2).gameObject;
            enemyTurnCheck.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {

        //if (')
        //{

        //}
        TurnText.text = ((int)runTime).ToString() + " Turn";

        if(turnOnOff == true)
        {
            runTime += Time.deltaTime;
            turnTime += Time.deltaTime;
        }
        else
        {
            //runTime = runTime;
        }
        //runTime += Time.deltaTime;

        if(DropPoint.uCard != null)
        {
            playerCardInfo[0].itemName = DropPoint.uCard.itemName;
            playerCardInfo[0].itemDescription = DropPoint.uCard.itemDescription;
            playerCardInfo[0].reinforceValue = DropPoint.uCard.reinforceValue;
            playerCardInfo[0].turnCost = DropPoint.uCard.turnCost;
            playerCardInfo[0].cardType = DropPoint.uCard.cardType;
            playerCardInfo[0].damageValue = DropPoint.uCard.damageValue;
            playerTurnCost = playerCardInfo[0].turnCost;
            turnOnOff = true;

            PlayerCostActive(); // 플레이어 카드의 코스트를 받아온 후 비활성화된 코스트 이미지 활성화
            
            //EnemyCostActive();
            if (playerFillCheck.GetComponent<Image>().fillAmount != 1 && turnOnOff == true)
            {
                CardTouchBlock.SetActive(true);
                PlayerTurnChecker();
            }
            if (playerFillCheck.GetComponent<Image>().fillAmount == 1)
            {
                DropPoint.uCard = null; //해당 업데이트안에 있는 if문 발동 해제용
                Destroy(DropPoint.cardObject);
                turnTime = 0;
                turnOnOff = false;
                CardTouchBlock.SetActive(false);
                //BattleStart();
                playerFillCheck.GetComponent<Image>().fillAmount = .0f; // 배틀 끝나고 초기화
            }
        }
        

        //if (GameOn())
      //  {
            //PlayerTurnChecker();
      //  }

    }

    public void BattleStart()
    {
        CardTouchBlock.SetActive(false);
        PlayerCostActive(); // 플레이어 카드의 코스트를 받아온 후 비활성화된 코스트 이미지 활성화
        EnemyCostActive();
    }

    //private void StartGame()
    //{
    //    turnOnOff = true;
    //}



    private void PlayerTurnChecker()
    {
        if (playerTurnCost == 1)
        {
            playerFillCheck.GetComponent<Image>().fillAmount = turnTime / playerTurnCost;
        }
        else if (playerTurnCost == 2)
        {
            playerFillCheck.GetComponent<Image>().fillAmount = turnTime / playerTurnCost;
        }
        else if (playerTurnCost == 3)
        {
            playerFillCheck.GetComponent<Image>().fillAmount = turnTime / playerTurnCost;
        }
    }

    private void EnemyTurnChecker()
    {
        if (enemyTurnCost == 1)
        {
            enemyFillCheck.GetComponent<Image>().fillAmount += Time.deltaTime / enemyTurnCost;
        }
        else if (enemyTurnCost == 2)
        {
            enemyFillCheck.GetComponent<Image>().fillAmount += Time.deltaTime / enemyTurnCost;
        }
        else if (enemyTurnCost == 3)
        {
            enemyFillCheck.GetComponent<Image>().fillAmount += Time.deltaTime / enemyTurnCost;
        }
    }

}
