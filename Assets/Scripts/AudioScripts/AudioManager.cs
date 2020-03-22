using UnityEngine.Audio;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Dictionary<string, Sound[]> soundDict = new Dictionary<string, Sound[]>();
    
    [Serializable]
    public struct SoundGroup
    {
        public string name;
        public Sound[] sounds;
    }
    public SoundGroup[] sGroups;

    void Awake() 
    {
        
        //This is a hack to effectively make a dictionary show up in the inspector, since Unity inspector doesn't recognize dictionaries.
        foreach(SoundGroup group in sGroups)
        {
            soundDict.Add(group.name, group.sounds);
        }
        
        foreach(KeyValuePair<string, Sound[]> entry in soundDict)
        {
            foreach(Sound s in entry.Value)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }
    }

    // Plays a random sound effect from the given category (based on the key in the dictionary)
    public void Play(string name)
    {
        System.Random rnd = new System.Random();
        int i;
        if(soundDict.TryGetValue(name, out Sound[] sArray))
        {
            i = rnd.Next(0, sArray.Length);
            sArray[i].source.Play();
        }
    }
}
