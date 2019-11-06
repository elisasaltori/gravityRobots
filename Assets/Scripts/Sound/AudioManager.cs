/*code example taken from
https://www.youtube.com/watch?v=6OT43pvUyfY */

using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;
            //s.source.outputAudioMixerGroup = s.output.outputAudioMixerGroup;

        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("stage"))
            Play("3..2..1..Go");
        else
            Play("Music");
  
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
