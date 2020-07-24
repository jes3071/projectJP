using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    public List<Card> playerCardInfo = new List<Card>(new Card[1]);
    public List<EnemyCard> enemyCardInfo = new List<EnemyCard>(new EnemyCard[1]);

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
    public GameObject victoryPopup;
    public GameObject defeatPopup;
    public GameObject pBackFill;
    public GameObject eBackFill;

    public Animator animator;

    public Player playerEquipCard;
    public Enemy enemyEquipCard;
    public EnemyCardInfo enemyCard;
    public PlayerDeck playerDeck;
    public PopupSystem mapCheck;
    public CardSpawn cardToHand;

    public Text TurnText;
    public Text blueSoulText;
    public Text redSoulText;
    public Text pDamagedText;
    public Text eDamagedText;

    public static int stageLevel = -1;
    public int lastLevel = -1;
    public static int randomMonster;
    public int redSoul;

    //public GameObject usingCard;

    public void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        CardTouchBlock = GameObject.Find("FixedUIHelper").transform.Find("UIBattlePlayerHand/CardTouchBlock").gameObject;
        victoryPopup = GameObject.Find("FixedUIHelper").transform.Find("UIBattleVictoryPopup").gameObject;
        defeatPopup = GameObject.Find("FixedUIHelper").transform.Find("UIBattleDefeatPopup").gameObject;
        pBackFill = GameObject.Find("FixedUIHelper").transform.Find("UIBattleField/Player/PlayerTurnState/PlayerTurnStateFill").gameObject;
        eBackFill = GameObject.Find("FixedUIHelper").transform.Find("UIBattleField/Enemy/EnemyTurnState/EnemyTurnStateFill").gameObject;
        //animator = GetComponent<Animator>();
        //StartCoroutine("GameStart");
    }

    public void Play()
    {
        if (stageLevel % 2 == 0)
        {
            randomMonster = Random.Range(0, 2);
        }
        else
        {
            randomMonster = Random.Range(0, 3);
        }
        
        animator.SetInteger("playerdamaged", -1);
        animator.SetInteger("enemydamaged", -1);
        PlayerCostInitialize();
        EnemyCostInitialize();
        victoryPopup.SetActive(false);
        pTimer = .0f;
        eTimer = .0f;
        enemyCard.DrawCard(); // 시작할때 적의 카드 드로우
        enemyTurnCost = enemyCard.turnCost;
        enemyEquipCard.Equip(); // 해당 카드 장착(공,방 및 데미지 확인)
        EnemyCostActive();

        TurnText.text = "0 Turn";
        runTime = .0f; // 전체 턴 수 측정용
        turnTime = .0f; //플레이어 턴코스트 제어용 0~1
        eTurnTime = .0f; //적 턴코스트 제어용 0~1
        Player.damageValue = 0;
        //Player.hp = 10;
        Player.shieldValue = 0;
        //Enemy.hp = 1;
        //Enemy.shieldValue = 0;
}

    public void PlayerCostInitialize()
    {
        for(int i = 0; i < 3; i++)
        {
            playerTurnCheck = GameObject.Find("FixedUIHelper").transform.Find("UIBattleField/Player/PlayerTurnState/PlayerTurnCost" + i).gameObject;
            playerTurnCheck.SetActive(true);
            playerFillCheck = GameObject.Find("PlayerTurnCostInner");
            playerFillCheck.GetComponent<Image>().fillAmount = .0f;
            playerTurnCheck.SetActive(false);
        }
        pBackFill.GetComponent<Image>().fillAmount = .0f;
        CardTouchBlock.GetComponent<Image>().raycastTarget = false;
        turnTime = 0;
        playerEquipCard.UnEquip();
        animator.SetInteger("enemydamaged", -1);
    }

    public void EnemyCostInitialize()
    {
        for (int i = 0; i < 3; i++)
        {
            enemyTurnCheck = GameObject.Find("EnemyTurnState").transform.Find("EnemyTurnCost" + i).gameObject;
            enemyTurnCheck.SetActive(true);
            enemyFillCheck = GameObject.Find("EnemyTurnCostInner");
            enemyFillCheck.GetComponent<Image>().fillAmount = .0f;
            enemyTurnCheck.SetActive(false);
        }
        eBackFill.GetComponent<Image>().fillAmount = .0f;
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
            playerTurnCheck = GameObject.Find("PlayerTurnState").transform.Find("PlayerTurnCost" + 0).gameObject;
            playerTurnCheck.SetActive(true);
        }
        else if (playerTurnCost == 2)
        {
            playerTurnCheck = GameObject.Find("PlayerTurnState").transform.Find("PlayerTurnCost" + 1).gameObject;
            playerTurnCheck.SetActive(true);
        }
        else if (playerTurnCost == 3) {
            playerTurnCheck = GameObject.Find("PlayerTurnState").transform.Find("PlayerTurnCost" + 2).gameObject;
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
            enemyTurnCheck = GameObject.Find("EnemyTurnState").transform.Find("EnemyTurnCost" + 0).gameObject;
            enemyTurnCheck.SetActive(true);
        }
        else if (enemyTurnCost == 2)
        {
            enemyTurnCheck = GameObject.Find("EnemyTurnState").transform.Find("EnemyTurnCost" + 1).gameObject;
            enemyTurnCheck.SetActive(true);
        }
        else if (enemyTurnCost == 3)
        {
            enemyTurnCheck = GameObject.Find("EnemyTurnState").transform.Find("EnemyTurnCost" + 2).gameObject;
            enemyTurnCheck.SetActive(true);
        }

        enemyFillCheck = GameObject.Find("EnemyTurnCostInner");
    }

    public void InsertPlayerCard()
    {
        playerCardInfo[0].index = DropPoint.uCard.index;
        playerCardInfo[0].itemName = DropPoint.uCard.itemName;
        playerCardInfo[0].itemDescription = DropPoint.uCard.itemDescription;
        playerCardInfo[0].itemType = DropPoint.uCard.itemType;
        playerCardInfo[0].turnCost = DropPoint.uCard.turnCost;
        playerCardInfo[0].cardType = DropPoint.uCard.cardType;
        playerCardInfo[0].damageValue = DropPoint.uCard.damageValue;
    }

    public void InsertEnemyCard()
    {
        enemyCardInfo[0].index = EnemyCardInfo.thisCard[0].index;
        enemyCardInfo[0].itemName = EnemyCardInfo.thisCard[0].itemName;
        enemyCardInfo[0].itemDescription = EnemyCardInfo.thisCard[0].itemDescription;
        enemyCardInfo[0].turnCost = EnemyCardInfo.thisCard[0].turnCost;
        enemyCardInfo[0].cardType = EnemyCardInfo.thisCard[0].cardType;
        enemyCardInfo[0].damageValue = EnemyCardInfo.thisCard[0].damageValue;
        enemyCardInfo[0].monsterType = EnemyCardInfo.thisCard[0].monsterType;
    }

    // Update is called once per frame
    void Update()
    {
        if(mapCheck.battleMap == true)
        {
            mapCheck.battleMap = false;
            StartCoroutine("GameStart");
        }

        TurnText.text = ((int)runTime).ToString() + " Turn";

        if (turnOnOff == true)
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
            eBackFill.GetComponent<Image>().fillAmount = eTurnTime / enemyTurnCost;
        }

        if (DropPoint.uCard != null)
        {
            InsertPlayerCard();
            InsertEnemyCard();
            playerTurnCost = playerCardInfo[0].turnCost;
            turnOnOff = true;
            PlayerCostActive(); // 플레이어 카드의 코스트를 받아온 후 비활성화된 코스트 이미지 활성화
            //EnemyCostActive();
            
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
                pBackFill.GetComponent<Image>().fillAmount = turnTime / playerTurnCost;

            }
            if (playerFillCheck.GetComponent<Image>().fillAmount == 1 &&
                enemyFillCheck.GetComponent<Image>().fillAmount == 1)
            {
                //플레이어랑 적 누가 방어를 사용했는지, 사용했으면 방어 먼저 사용하게
                if (playerCardInfo[0].cardType == 1 && enemyCardInfo[0].cardType == 2) // 공격 , 뒤에 && 적이 공격...등
                {
                    Enemy.shieldValue += Enemy.damageValue;
                    if(Player.damageValue > Enemy.shieldValue)
                    {
                        Enemy.hp -= (Player.damageValue - Enemy.shieldValue);
                        eDamagedText.text = (Player.damageValue - Enemy.shieldValue).ToString();
                        Enemy.shieldValue = 0;
                        animator.SetInteger("enemydamaged", 1);
                        //Debug.Log("적 피 깎임");
                    }
                    else if(Player.damageValue <= Enemy.shieldValue)
                    {
                        Enemy.shieldValue -= Player.damageValue;
                        //Debug.Log("적 실드 깎임");
                    }

                    if (Enemy.hp <= 0)
                    {
                        Enemy.hp = 0;
                        blueSoulText.text = enemyEquipCard.blueSoul.ToString();
                        redSoul = Random.Range(0, enemyEquipCard.maxRedSoul + 1);
                        redSoulText.text = redSoul.ToString();
                        Player.blueSoul += enemyEquipCard.blueSoul;
                        Player.redSoul += redSoul;
                        victoryPopup.SetActive(true);
                        //stageLevel++;
                    }
                }
                else if (playerCardInfo[0].cardType == 2 && enemyCardInfo[0].cardType == 1)
                {
                    Player.shieldValue += Player.damageValue;
                    if (Enemy.damageValue > Player.shieldValue)
                    {
                        Player.hp -= (Enemy.damageValue - Player.shieldValue);
                        pDamagedText.text = (Enemy.damageValue - Player.shieldValue).ToString();
                        Player.shieldValue = 0;
                        animator.SetInteger("playerdamaged", 1);
                        //Debug.Log("나 피 깎임");
                    }
                    else if (Enemy.damageValue <= Player.shieldValue)
                    {
                        Player.shieldValue -= Enemy.damageValue;
                        //Debug.Log("나 실드 깎임");
                    }

                    if (Player.hp <= 0)
                    {
                        Player.hp = 0;
                        defeatPopup.SetActive(true);
                    }

                }
                else if (playerCardInfo[0].cardType == 1 && enemyCardInfo[0].cardType == 1)
                {
                    //Debug.Log(Player.shieldValue);
                    //Debug.Log(Enemy.damageValue);
                    if (Player.shieldValue >= Enemy.damageValue)
                    {
                        Player.shieldValue -= Enemy.damageValue;
                        //Debug.Log("나 실드 깎임22");
                    }
                    else if(Player.shieldValue < Enemy.damageValue)
                    {
                        Player.hp -= (Enemy.damageValue - Player.shieldValue);
                        pDamagedText.text = (Enemy.damageValue - Player.shieldValue).ToString();
                        Player.shieldValue = 0;
                        animator.SetInteger("playerdamaged", 1);
                        //Debug.Log("나 피 깎임22");
                    }

                    if (Enemy.shieldValue >= Player.damageValue)
                    {
                        Enemy.shieldValue -= Player.damageValue;
                        //Debug.Log("적 실드 깎임22");
                    }
                    else if (Enemy.shieldValue < Player.damageValue)
                    {
                        Enemy.hp -= (Player.damageValue - Enemy.shieldValue);
                        eDamagedText.text = (Player.damageValue - Enemy.shieldValue).ToString();
                        Enemy.shieldValue = 0;
                        animator.SetInteger("enemydamaged", 1);
                        //Debug.Log("적 피 깎임22");
                    }

                    if (Player.hp <= 0)
                    {
                        Player.hp = 0;
                        defeatPopup.SetActive(true);
                    }
                    else if (Enemy.hp <= 0 && Player.hp > 0)
                    {
                        Enemy.hp = 0;
                        blueSoulText.text = enemyEquipCard.blueSoul.ToString();
                        redSoul = Random.Range(0, enemyEquipCard.maxRedSoul + 1);
                        redSoulText.text = redSoul.ToString();
                        Player.blueSoul += enemyEquipCard.blueSoul;
                        Player.redSoul += redSoul;
                        victoryPopup.SetActive(true);
                        //stageLevel++;
                    }
                }
                else if(playerCardInfo[0].cardType == 2 && enemyCardInfo[0].cardType == 2)
                {
                    Player.shieldValue += Player.damageValue;
                    Enemy.shieldValue += Enemy.damageValue;
                }

                Invoke("EnemyEquipCtrl", 1);
                PlayerEquipCtrl();
                //Debug.Log("동시");
            }
            else if (playerFillCheck.GetComponent<Image>().fillAmount == 1)
            {
                if(playerCardInfo[0].cardType == 1)
                {
                    if (Enemy.shieldValue >= Player.damageValue)
                    {
                        Enemy.shieldValue -= Player.damageValue;
                        //Debug.Log("적 실드 깎임");
                    }
                    else if (Enemy.shieldValue < Player.damageValue)
                    {
                        Enemy.hp -= (Player.damageValue - Enemy.shieldValue);
                        eDamagedText.text = (Player.damageValue - Enemy.shieldValue).ToString();
                        Enemy.shieldValue = 0;
                        animator.SetInteger("enemydamaged", 1);
                        //Debug.Log("적 피 깎임");
                    }

                    if(Enemy.hp <= 0)
                    {
                        Enemy.hp = 0;
                        blueSoulText.text = enemyEquipCard.blueSoul.ToString();
                        redSoul = Random.Range(0, enemyEquipCard.maxRedSoul + 1);
                        redSoulText.text = redSoul.ToString();
                        Player.blueSoul += enemyEquipCard.blueSoul;
                        Player.redSoul += redSoul;
                        victoryPopup.SetActive(true);
                        //stageLevel++;
                    }
                }
                else if(playerCardInfo[0].cardType == 2)
                {
                    Player.shieldValue += Player.damageValue;
                }

                PlayerEquipCtrl();
                //Debug.Log("플레이어 먼저");
            }
            else if (enemyFillCheck.GetComponent<Image>().fillAmount == 1)
            {
                if(enemyCardInfo[0].cardType == 1)
                {
                    if (Player.shieldValue >= Enemy.damageValue)
                    {
                        Player.shieldValue -= Enemy.damageValue;
                        //Debug.Log("나 실드 깎임");
                    }
                    else if (Player.shieldValue < Enemy.damageValue)
                    {
                        Player.hp -= (Enemy.damageValue - Player.shieldValue);
                        pDamagedText.text = (Enemy.damageValue - Player.shieldValue).ToString();
                        Player.shieldValue = 0;
                        animator.SetInteger("playerdamaged", 1);
                        //Debug.Log(runTime);
                        //Debug.Log("나 피 깎임");
                    }

                    if (Player.hp <= 0)
                    {
                        Player.hp = 0;
                        defeatPopup.SetActive(true);
                    }
                }
                else if(enemyCardInfo[0].cardType == 2)
                {
                    Enemy.shieldValue += Enemy.damageValue;
                }

                EnemyEquipCtrl();
                //Invoke("EnemyEquipCtrl", 1);
                //Debug.Log("적 먼저");
            }
        }
    }

    public void PlayerEquipCtrl()
    {
        //cardToHand.ReDraw();
        turnOnOff = false;
        //animator.SetInteger("playerdamaged", -1);
        //animator.SetInteger("enemydamaged", -1);
        playerEquipCard.Apply(); // 공 방 적용
        DropPoint.uCard = null; //해당 업데이트안에 있는 if문 발동 해제용
        Destroy(DropPoint.cardObject);
        Invoke("PlayerCostInitialize", 1);
    }

    public void EnemyEquipCtrl()
    {
        //animator.SetInteger("playerdamaged", -1);
        
        Invoke("PlayerDamagedReset", 1);
        enemyEquipCard.Apply();
        eTurnTime = 0;
        enemyEquipCard.UnEquip();
        enemyCard.DrawCard(); // 시작할때 적의 카드 드로우
        enemyTurnCost = enemyCard.turnCost;
        enemyEquipCard.Equip(); // 해당 카드 장착(공,방 및 데미지 확인)
        enemyFillCheck.GetComponent<Image>().fillAmount = .0f;
        EnemyCostActive();
        eBackFill.GetComponent<Image>().fillAmount = .0f;
    }

    public void PlayerDamagedReset()
    {
        animator.SetInteger("playerdamaged", -1);
        //Debug.Log(runTime);
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

    IEnumerator GameStart()
    {
        Play();
        yield return null;
    }

}
