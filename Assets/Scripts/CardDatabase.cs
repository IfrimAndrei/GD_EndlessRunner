using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();
    void Awake()
    {
        cardList.Add(new Minion(0,"Bob the ferret", 1, "A simple legendary ferret",Resources.Load<Sprite>("ferret"), 1, 3, true, true, false,null,null));
        cardList.Add(new Minion(1, "Alfred the whale", 10, "Mighty Fat Whale", Resources.Load<Sprite>("whale"), 10, 10, true, true, false, null, null));
        cardList.Add(new Minion(2, "Fred Bearcury", 5, "Bearable singer", Resources.Load<Sprite>("bear"), 2, 4, true, true, false, null, null));
        cardList.Add(new Spell(3,"Fireball", 4, "Deal 6 damage to anything", Resources.Load<Sprite>("fireball"), null));
    }
    
}
