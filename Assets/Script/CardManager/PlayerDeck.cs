using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDeck : MonoBehaviour {

    public static List<Card> playerDeck = new List<Card>(new Card[10]);
    public List<Card> container = new List<Card>(new Card[10]);

    public int x;
    public static int deckSize;

    public GameObject Deck;

    private void Awake()
    {
        Deck = GetComponent<GameObject>();
    }

    // Use this for initialization
    void Start () {

        x = 0;
        deckSize = 20;

        //플레이어 덱에 구성되는 10장의 카드
        for (int i = 0; i < deckSize; i++) 
        {
            if(CardDataBase.cardList[i].inPlayerDeck == 1)
            {
                playerDeck[x] = CardDataBase.cardList[i];
                x++;
            }
            //x = Random.Range(0, 19);
            //playerDeck[i] = CardDataBase.cardList[i];
        }

        //SeeDeck();

        //StartCoroutine(StartGame());

    }



	// Update is called once per frame
	void Update () {
        for (int j = 0; j < playerDeck.Count; j++)
        {
            if (playerDeck[j].inPlayerHand == 1)
            {
                playerDeck.RemoveAt(j);
                //container.RemoveAt(j);
                //Debug.Log("1");
            }

        }
        for (int i = 0; i < playerDeck.Count; i++)
        {
            container[i] = playerDeck[i];
        }

        //SeeDeck();

    }

    public void SeeDeck()
    {
        if(Deck.activeSelf == true)
            Deck.SetActive(false);
        else
            Deck.SetActive(true);

        for (int i = 0; i < playerDeck.Count; i++)
        {
            Debug.Log(playerDeck[i].itemName);
        }
        
    }

    //public void Shuffle()
    //{
    //    for (int i = 0; i < deckSize; i++)
    //    {
    //        container[0] = playerDeck[i];
    //        int randomIndex= Random.Range(i, deckSize);
    //        playerDeck[i] = playerDeck[randomIndex];
    //        playerDeck[randomIndex] = container[0];
    //    }
    //}

    //IEnumerator Example()
    //{
    //    yield return new WaitForSeconds(1);
    //    Clones = GameObject.FindGameObjectsWithTag("Clones");

    //    foreach(GameObject Clone in Clones)
    //    {
    //        Destroy(Clone);
    //    }
    //}

    //IEnumerator StartGame()
    //{
    //    for(int i = 0; i < 4; i++)
    //    {
    //        yield return new WaitForSeconds(1);
    //        Instantiate(CardToHand, transform.position, transform.rotation);
    //    }
    //}

}
