using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Text Score;
    public Text Cherry;
    public static int score = 0;
    void Start()
    {
        
    }
    void Update()
    {
        Score.text = score.ToString();
        Cherry.text = GameManager.cherry.ToString();

    }

    public static void updateScore() {
        score++;
    }
}
