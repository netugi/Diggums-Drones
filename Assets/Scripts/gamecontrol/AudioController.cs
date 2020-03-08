using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    AudioSource audioSong;
    void Start()
    {
		audioSong = GetComponent<AudioSource>();
    }
}
