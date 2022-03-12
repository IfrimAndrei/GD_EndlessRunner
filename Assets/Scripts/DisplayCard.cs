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

    void Start()
    {
        displayCard = new List<Card>(CardDatabase.cardList);
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

    }
}
