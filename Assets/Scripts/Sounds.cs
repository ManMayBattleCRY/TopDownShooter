using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource audioSrc;

    public AudioClip[] sounds;
    Transform _tr => transform;


    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    public void PlaySound(AudioClip sound , float pitch1 = 1f, float pitch2 = 1f, float volume = 1f,   bool destroyed = false)
    {
        audioSrc.pitch = Random.Range(pitch1, pitch2);

        if (destroyed) AudioSource.PlayClipAtPoint(sound , _tr.position , volume);
        else
            audioSrc.PlayOneShot(sound , volume);
    }

}
