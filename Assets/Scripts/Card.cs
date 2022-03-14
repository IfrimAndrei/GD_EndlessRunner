using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Card //: ScriptableObject
{
    public int id;
    public string cardName;
    public int cost;
    public string description;
    public Sprite image;

    //effect
    //list (matricea de combat) targets

    public Card()
    {

    }
    public Card(int Id, string CardName, int Cost, string Description,Sprite Image)
    {
        id=Id;
        cardName=CardName;
        cost=Cost;
        description=Description;
        image = Image;
    }
    public string toString() {
        return "id: " + id + " cardName: " + cardName + " cost: " + cost + " description: " + description;
    }
}
