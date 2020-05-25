using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private AudioSource audioSrc;

    private AudioClip[] deathSounds;

    private int randomDeathSound;

    void Start()
    {
        instance = this;
        audioSrc = GetComponent<AudioSource>();
        deathSounds = Resources.LoadAll<AudioClip>("DeathSounds");
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
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
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    public void PlayDeathSound()
    {
        randomDeathSound = UnityEngine.Random.Range(0, 3);
        audioSrc.PlayOneShot(deathSounds[randomDeathSound]);
    }
}
