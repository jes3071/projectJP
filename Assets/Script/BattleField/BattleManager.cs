using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    public List<Card> playerCardInfo = new List<Card>(new Card[1]);

    public int tictok = 100;
    public int curTic;
    public int totalTurn;

    public static bool turnOnOff = false; // 플레이어에게 턴을 넘겨주기 위한 용도

    float pTimer; // 플레이어 턴코스트 1칸씩 차오르게 보이는 용도
    float eTimer; // 적 턴코스트 1칸씩 차오르게 보이는 용도

    public float runTime = .0f; // 전체 턴 수 측정용


    public float turnTime = .0f; //플레이어 턴코스트 제어용 0~1
    public float eTurnTime = .0f; //적 턴코스트 제어용 0~1


    public int playerTurnCost = 3; // 받아올 예정
    public int enemyTurnCost = 1;
    public GameObject playerFillCheck;
    public GameObject enemyFillCheck;
    public GameObject playerTurnCheck;
    public GameObject enemyTurnCheck;

    public GameObject CardTouchBlock;

    public Player playerEquipCard;
    public Enemy enemyEquipCard;

    public EnemyCardInfo enemyCard;

    public PlayerDeck playerDeck;

    public Text TurnText;

    public static int stageLevel = 0;

    //public GameObject usingCard;

    public void Awake()
    {
        CardTouchBlock = GameObject.Find("CardTouchBlock");
    }

    // Use this for initialization
    void Start () {
        
        pTimer = .0f;
        eTimer = .0f;
        PlayerCostInitialize();
        EnemyCostInitialize();
        enemyCard.DrawCard(); // 시작할때 적의 카드 드로우
        enemyTurnCost = enemyCard.turnCost;
        enemyEquipCard.Equip(); // 해당 카드 장착(공,방 및 데미지 확인)
        EnemyCostActive();

        TurnText.text = "0 Turn";
    }

    public void PlayerCostInitialize()
    {
        for(int i = 0; i < 3; i++)
        {
            playerTurnCheck = GameObject.Find("Player").transform.Find("PlayerTurnCost" + i).gameObject;
            playerTurnCheck.SetActive(true);
            playerFillCheck = GameObject.Find("PlayerTurnCostInner");
            playerFillCheck.GetComponent<Image>().fillAmount = .0f;
            playerTurnCheck.SetActive(false);

            
        }
        CardTouchBlock.GetComponent<Image>().raycastTarget = false;
    }

    public void EnemyCostInitialize()
    {
        for (int i = 0; i < 3; i++)
        {
            enemyTurnCheck = GameObject.Find("Enemy").transform.Find("EnemyTurnCost" + i).gameObject;
            enemyTurnCheck.SetActive(true);
            enemyFillCheck = GameObject.Find("EnemyTurnCostInner");
            enemyFillCheck.GetComponent<Image>().fillAmount = .0f;
            enemyTurnCheck.SetActive(false);
        }
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
            playerTurnCheck = GameObject.Find("Player").transform.Find("PlayerTurnCost" + 0).gameObject;
            playerTurnCheck.SetActive(true);
        }
        else if (playerTurnCost == 2)
        {
            playerTurnCheck = GameObject.Find("Player").transform.Find("PlayerTurnCost" + 1).gameObject;
            playerTurnCheck.SetActive(true);
        }
        else if (playerTurnCost == 3) {
            playerTurnCheck = GameObject.Find("Player").transform.Find("PlayerTurnCost" + 2).gameObject;
            playerTurnCheck.SetActive(true);
        }

        playerFillCheck = GameObject.Find("PlayerTurnCostInner");
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
            enemyTurnCheck = GameObject.Find("Enemy").transform.Find("EnemyTurnCost" + 0).gameObject;
            enemyTurnCheck.SetActive(true);
        }
        else if (enemyTurnCost == 2)
        {
            enemyTurnCheck = GameObject.Find("Enemy").transform.Find("EnemyTurnCost" + 1).gameObject;
            enemyTurnCheck.SetActive(true);
        }
        else if (enemyTurnCost == 3)
        {
            enemyTurnCheck = GameObject.Find("Enemy").transform.Find("EnemyTurnCost" + 2).gameObject;
            enemyTurnCheck.SetActive(true);
        }

        enemyFillCheck = GameObject.Find("EnemyTurnCostInner");
    }

    // Update is called once per frame
    void Update () {
        
        TurnText.text = ((int)runTime).ToString() + " Turn";

        if(turnOnOff == true)
        {
            runTime += Time.deltaTime;
            turnTime += Time.deltaTime;
            eTurnTime += Time.deltaTime;

            eTimer += Time.deltaTime;

            if (eTimer > 1.0f)
            {
                //Action
                EnemyTurnChecker();
                eTimer = 0;
            }

        }
        else
        {
            //enemyCard.DrawCard(); // 시작할때 적의 카드 드로우
            //enemyEquipCard.Equip(); // 해당 카드 장착(공,방 및 데미지 확인)
            //EnemyCostActive();

            //if(DropPoint.uCard != null)
            //{
            //    turnOnOff = true;
            //    Debug.Log("!");
            //}
            //runTime = runTime;
        }
        //runTime += Time.deltaTime;

        if (DropPoint.uCard != null)
        {
            playerCardInfo[0].itemName = DropPoint.uCard.itemName;
            playerCardInfo[0].itemDescription = DropPoint.uCard.itemDescription;
            playerCardInfo[0].itemType = DropPoint.uCard.itemType;
            playerCardInfo[0].turnCost = DropPoint.uCard.turnCost;
            playerCardInfo[0].cardType = DropPoint.uCard.cardType;
            playerCardInfo[0].damageValue = DropPoint.uCard.damageValue;
            playerTurnCost = playerCardInfo[0].turnCost;
            turnOnOff = true;

            PlayerCostActive(); // 플레이어 카드의 코스트를 받아온 후 비활성화된 코스트 이미지 활성화
            EnemyCostActive();
            

            //EnemyCostActive();
            if (playerFillCheck.GetComponent<Image>().fillAmount != 1 ||
                enemyFillCheck.GetComponent<Image>().fillAmount != 1 && turnOnOff == true)
            {
                CardTouchBlock.GetComponent<Image>().raycastTarget = true;
                //CardTouchBlock.SetActive(true);
                pTimer += Time.deltaTime;

                if (pTimer > 1.0f)
                {
                    //Action
                    PlayerTurnChecker();
                    pTimer = 0;
                }

            }
            if (playerFillCheck.GetComponent<Image>().fillAmount == 1 &&
                enemyFillCheck.GetComponent<Image>().fillAmount == 1)
            {
                //플레이어랑 적 누가 방어를 사용했는지, 사용했으면 방어 먼저 사용하게
                //if (playerCardInfo[0].cardType == 1) // 공격 , 뒤에 && 적이 공격...등
                //{
                //    Enemy.hp -= Player.damageValue;
                //    Debug.Log("적을 공격!");
                //}

                EnemyEquipCtrl();
                PlayerEquipCtrl();
                Debug.Log("동시");
            }
            else if (playerFillCheck.GetComponent<Image>().fillAmount == 1)
            {
                //if (playerCardInfo[0].cardType == 1) // 공격 , 뒤에 && 적이 공격...등
                //{
                //    Enemy.hp -= Player.damageValue;
                //    Debug.Log("적을 공격!");
                //}
                PlayerEquipCtrl();
                Debug.Log("플레이어 먼저");
            }
            else if (enemyFillCheck.GetComponent<Image>().fillAmount == 1)
            {

                EnemyEquipCtrl();
                Debug.Log("적 먼저");
            }
        }
    }

    public void BattleStart()
    {
        CardTouchBlock.SetActive(false);
        PlayerCostActive(); // 플레이어 카드의 코스트를 받아온 후 비활성화된 코스트 이미지 활성화
        EnemyCostActive();
    }

    public void PlayerEquipCtrl()
    {
        playerEquipCard.Apply(); // 공 방 적용
        DropPoint.uCard = null; //해당 업데이트안에 있는 if문 발동 해제용
        Destroy(DropPoint.cardObject);
        turnTime = 0;
        turnOnOff = false;
        playerEquipCard.UnEquip();
        Invoke("PlayerCostInitialize", 1);
    }

    public void EnemyEquipCtrl()
    {
        enemyEquipCard.Apply();
        eTurnTime = 0;
        enemyEquipCard.UnEquip();
        enemyCard.DrawCard(); // 시작할때 적의 카드 드로우
        enemyTurnCost = enemyCard.turnCost;
        enemyEquipCard.Equip(); // 해당 카드 장착(공,방 및 데미지 확인)
        enemyFillCheck.GetComponent<Image>().fillAmount = .0f;
        EnemyCostActive();
        //Invoke("EnemyCostInitialize", 1);

    }
    
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
            enemyFillCheck.GetComponent<Image>().fillAmount = eTurnTime / enemyTurnCost;
        }
        else if (enemyTurnCost == 2)
        {
            enemyFillCheck.GetComponent<Image>().fillAmount = eTurnTime / enemyTurnCost;
        }
        else if (enemyTurnCost == 3)
        {
            enemyFillCheck.GetComponent<Image>().fillAmount = eTurnTime / enemyTurnCost;
        }
    }

}
