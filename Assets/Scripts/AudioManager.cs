using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource audioSource;
    public const string VOLUME_LEVEL = "VolumeLevel";
    public const float DEFAULT_VALUE = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        float volume = PlayerPrefs.GetFloat(VOLUME_LEVEL, DEFAULT_VALUE);
        audioSource.volume = volume;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustVolume(float level)
    {
        audioSource.volume = level;
        PlayerPrefs.SetFloat("VolumeLevel", level);

    }
}
