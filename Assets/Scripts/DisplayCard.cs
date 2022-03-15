using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
    public string cardName;
    public int cost;
    public string description;
    public Sprite image;

    public Text nameText;
    public Text costText;
    public Text descriptionText;
    public Text attack;
    public Text health;
    public Image artWork;

    public bool cardBackOn; //=true
    public GameObject cardBack;


    public static bool staticCardBack;
    public GameObject Hand;
    public int numberOfCardsInDeck;

    void Start()
    {
        displayCard = new List<Card>(CardDatabase.cardList);
        numberOfCardsInDeck = PlayerDeck.deckSize; 
    }
    void Update()
    {
        
        nameText.text = "" + displayCard[displayId].cardName;
        costText.text = "" + displayCard[displayId].cost;
        descriptionText.text = "" + displayCard[displayId].description;
        artWork.sprite = displayCard[displayId].image;
        if (displayCard[displayId].GetType() == typeof(Minion))
        {
            Minion aux = (Minion)displayCard[displayId];
            attack.text = "" + aux.attack;
            health.text = "" + aux.health;
        }
        else
        {
            attack.text = "" ;
            health.text = "" ;
        }
        cardBack.SetActive(cardBackOn);

    
        Hand = GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent) {
             cardBackOn = true;
         }
         if(this.tag == "Clone") {
            displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -=1;
            PlayerDeck.deckSize -=1;
            cardBackOn = false;
            this.tag = "Untagged";
         }
    }
}
