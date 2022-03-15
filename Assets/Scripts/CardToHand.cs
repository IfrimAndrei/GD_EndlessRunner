using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CardToHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject HandCard;
    void Start()
    {
        Hand = GameObject.Find("Hand");
        HandCard.transform.SetParent(Hand.transform);
        HandCard.transform.localScale = Vector3.one;
        HandCard.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        HandCard.transform.eulerAngles = new Vector3(25, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
