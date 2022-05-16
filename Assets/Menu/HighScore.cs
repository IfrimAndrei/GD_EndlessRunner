using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI textElem;
    // Start is called before the first frame update
    void Start()
    {   
        
        int score = PlayerPrefs.HasKey("highscore") ? PlayerPrefs.GetInt("highscore") : 0;
        textElem.text = "Highscore: " + score;
    }

    // Update is called once per frame

}
