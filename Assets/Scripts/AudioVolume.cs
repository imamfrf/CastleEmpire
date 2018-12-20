using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioVolume : MonoBehaviour {

    // Use this for initialization
    public Slider volumeSlider;
    public AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    //float m_MySliderValue;

    void Start()
    {
        //Initiate the Slider value to half way
       // m_MySliderValue = 0.5f;
        //Fetch the AudioSource from the GameObject
        //m_MyAudioSource = GetComponent<AudioSource>();
        //Play the AudioClip attached to the AudioSource on startup
        m_MyAudioSource.Play();
    }

    private void Update()
    {
        m_MyAudioSource.volume = volumeSlider.value;
    }
}
