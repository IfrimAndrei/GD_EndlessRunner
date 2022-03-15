using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public static int maxHP;
    public int playerCurrentHP;
    public int opponentCurrentHP;
    public Text playerCurrnetHPText;
    public Text opponentCurrentHPText;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = 30;
        playerCurrentHP = maxHP;
        opponentCurrentHP = maxHP;
        playerCurrnetHPText.text = "" + playerCurrentHP;
        opponentCurrentHPText.text = "" + opponentCurrentHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHP > maxHP)
            playerCurrentHP = maxHP;
        if (opponentCurrentHP > maxHP)
            opponentCurrentHP = maxHP;

        playerCurrnetHPText.text = "" + playerCurrentHP;
        opponentCurrentHPText.text = "" + opponentCurrentHP;
    }
}
