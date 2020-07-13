using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyDeck : MonoBehaviour {

    public static List<Card> enemyDeck = new List<Card>(new Card[10]);
    public List<Card> container = new List<Card>(new Card[10]);

    public int x;
    public int y;
    public static int deckSize;

    public GameObject CardToHand;
    public GameObject CardBack;
    public GameObject Deck;

    public GameObject[] Clones;

    public GameObject Hand;

    // Use this for initialization
    void Start () {

        x = 0;
        deckSize = 20;

        //플레이어 덱에 구성되는 10장의 카드
        for (int i = 0; i < deckSize; i++) 
        {
            if(CardDataBase.cardList[i].inPlayerDeck == 1)
            {
                enemyDeck[x] = CardDataBase.cardList[i];
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
        for (int j = 0; j < enemyDeck.Count; j++)
        {
            if (enemyDeck[j].inPlayerHand == 1)
            {
                enemyDeck.RemoveAt(j);
                //container.RemoveAt(j);
                //Debug.Log("1");
            }

        }
        for (int i = 0; i < enemyDeck.Count; i++)
        {
            container[i] = enemyDeck[i];
        }



    }

    public void SeeDeck()
    {
        for (int i = 0; i < enemyDeck.Count; i++)
        {
            container[i] = enemyDeck[i];
        }
        x = 0;
        for(int j = 0; j < enemyDeck.Count; j++)
        {
            if(enemyDeck[j].inPlayerHand == 1)
            {
                enemyDeck[x] = enemyDeck[j];
                //playerDeck.RemoveAt(j);
                x++;
            }
            
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = enemyDeck[i];
            int randomIndex= Random.Range(i, deckSize);
            enemyDeck[i] = enemyDeck[randomIndex];
            enemyDeck[randomIndex] = container[0];
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clones");

        foreach(GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }

    IEnumerator StartGame()
    {
        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

}
