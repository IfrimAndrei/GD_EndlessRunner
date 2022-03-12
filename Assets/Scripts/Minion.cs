using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion :  Card
{
    public int attack;
    public int health;
    public bool canAttack;
    public bool canBlock;
    public bool barrier;
    //public image/artwork
    public Effect battlecry;
    public Effect deathwish;

    public Minion(Minion aux)
    {
        attack = aux.attack;
        health = aux.health;
    }
    public Minion(int Id, string CardName, int Cost, string Description, Sprite Image,
        int Attack, int Health, bool CanAttack, bool CanBlock, bool Barrier, Effect Battlecry, Effect Deathwish)
        : base(Id, CardName, Cost, Description, Image)
    {
        attack = Attack;
        health = Health;
        canAttack = CanAttack;
        canBlock = CanBlock;
        barrier = Barrier;
        battlecry = Battlecry;
        deathwish = Deathwish;
    }

}
