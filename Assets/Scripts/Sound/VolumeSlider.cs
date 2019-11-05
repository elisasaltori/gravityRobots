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
        /*gets the master volume value, undoes the log conversion
         * and sets the value to the volume slider*/
        float volume;
        audioMixer.GetFloat("Volume", out volume);

        /*the log conversion get undone(inverts log10(volume)*20)*/
        float delogedvolume = volume / 20;
        delogedvolume = Mathf.Pow(10, delogedvolume);

        GetComponent<Slider>().value = delogedvolume;
    }

}
