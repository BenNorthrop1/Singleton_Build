using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManagerSingleton : MonoBehaviour
{
   
    public Sound[] sounds;

    public static SoundManagerSingleton instance;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }



        void Start()
        {
            Play("Theme");
        }

        public void Play (string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if(s == null)
            {
            Debug.LogWarning("Sound" + name + "name Found!");
            return;
            }
            s.source.Play();
        }



    
}
