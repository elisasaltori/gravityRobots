using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//Sets slider to current volume when starting main menu
public class VolumeSlider : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        float volume;
        audioMixer.GetFloat("Volume", out volume);

        GetComponent<Slider>().value = volume;
    }

}
