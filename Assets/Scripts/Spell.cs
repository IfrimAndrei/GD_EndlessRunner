using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spell : Card
{
    public Effect ability;
    public Spell(int Id, string CardName, int Cost, string Description, Sprite Image,
        Effect Ability) 
        :base(Id,  CardName,  Cost,  Description, Image)
    {
        ability = Ability;
    }
}
