using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioBetweenScenes : MonoBehaviour
{
    AudioSource audioSource;
    private static AudioBetweenScenes instance = null;
    public static AudioBetweenScenes Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
        }

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
