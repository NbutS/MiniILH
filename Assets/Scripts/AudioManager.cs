using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

   public static AudioManager instance;


    private void Awake()
    {
        
        
        if (instance == null)
        {
            PlayerPrefs.SetInt("Music On", 1);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;
        }
    } 
    public void Play( string name )
    {
        Sound s = Array.Find( sounds, sound => sound.name == name );
        s.source.Play();
        
    }
    public void PauseMusic( string name )
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
       
    }    
   
    
}
