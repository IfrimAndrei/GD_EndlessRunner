using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioBetweenScenes : MonoBehaviour
{
    AudioSource audioSource;
    public Slider volumeSlider;
    // Start is called before the first frame update
    // void Awake() {
        // DontDestroyOnLoad(transform.gameObject);
    // }

    void Start() {
        DontDestroyOnLoad(transform.gameObject);

        audioSource = GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("musicVolume")){
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
        }

    }
}
