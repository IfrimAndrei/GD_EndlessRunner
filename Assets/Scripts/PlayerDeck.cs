using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();
    public static int deckSize;
    public GameObject deckCard1;
    public GameObject deckCard2;
    public GameObject deckCard3;
    public GameObject deckCard4;

    public GameObject[] Clones;
    public GameObject Hand;
    public GameObject CardToHand;

    //Start is called before the first frame update
    void Start()
    {
        deckSize = 30;
        int maxRandom = CardDatabase.cardList.Count;
        for (int index = 0; index < deckSize; index++)
        {
            int randomIndex = Random.Range(0, maxRandom);
            deck.Add(CardDatabase.cardList[randomIndex]);
        }
        
        StartCoroutine(StartGame());
    }
    // for debugging
    private void PrintDeck()
    {
        string deckString = "";
        foreach (Card card in deck)
            deckString += card.toString() + "\n";
        print(deckString);
    }
    // Update is called once per frame
    void Update()
    {   
        staticDeck = deck; 
        if (deckSize < 20)
            deckCard1.SetActive(false);
        if (deckSize < 10)
            deckCard2.SetActive(false);
        if (deckSize < 2)
            deckCard3.SetActive(false);
        if (deckSize < 1)
            deckCard4.SetActive(false);

        if (TurnSystem.startTurn == true)
        {
            StartCoroutine(Draw(1));
            TurnSystem.startTurn = false;
        }
    }
    // IEnumerator Example() {
    //     yield return new WaitForSeconds(1);
    //     Clones = GameObject.FindGameObjectsWithTag("Clone");
    //     foreach(GameObject Clone in Clones) {
    //         Destroy(Clone);
    //     }
    // }
    IEnumerator StartGame()
    {
        for(int i=0; i<=4; i++) {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
    /*
    public void Shuffle()
    {
        // PrintDeck();
        for (int index = 0; index < deckSize; index++)
        {
            int randomIndex = Random.Range(0, deckSize);
            Card aux = deck[randomIndex];
            deck[randomIndex] = deck[index];
            deck[index] = aux;
        }
        // PrintDeck();

    }
    */

    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
}
