using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Audio[] sounds;

    public static AudioManager instance;

    //Use this for initialization
    Audio ss;
    void Awake()
    {
        // use for music continue between scene
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else 
        {
            Destroy(gameObject);
            return;
        }
   

        foreach (Audio s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    public void audio_play(string name) 
    {
        ss = Array.Find(sounds, sound => sound.name == name);
        if (ss == null || ss.source == null) 
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        ss.source.Play();
         
    }
    public void StopAudio() 
    {
        if (ss == null) 
        {

            return;
        }
        ss.source.Stop();
        ss = null;
    }
}
