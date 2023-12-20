using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMControl : MonoBehaviour
{
    public Music[] musicList;

    private AudioSource audioSource;
    public MusicDisplayer musicDisplayer = null;

    public void PlayRandomMusic()
    {
        if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        int randomIndex = Random.Range(0, musicList.Length);
        Music randomMusic = musicList[randomIndex];
        audioSource.clip = randomMusic.musicClip;
        audioSource.Play();

        notifyUIChangeMusic(randomMusic);
    }

    public void notifyUIChangeMusic(Music music)
    {
        if (musicDisplayer != null)
        {
            musicDisplayer.DisplayMusic(music);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }
}
