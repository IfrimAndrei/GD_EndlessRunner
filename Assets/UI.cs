using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Text Score;
    public Text Cherry;
    void Start()
    {
        
    }
    void Update()
    {
        Score.text = BlockSpawner.waveCounter.ToString();
        Cherry.text = GameManager.cherry.ToString();

    }
}
