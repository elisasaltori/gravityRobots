﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    /*function to set the volume*/
    public void SetVolume (float volume)
    {
        Debug.Log(volume);//print the volume value
        audioMixer.SetFloat("Volume", volume);
    }
}
