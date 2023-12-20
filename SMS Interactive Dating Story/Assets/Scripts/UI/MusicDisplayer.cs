using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicDisplayer : MonoBehaviour
{
    [SerializeField] GameObject musicDisplay;
    [SerializeField] TextMeshProUGUI musicNameDisplay;
    [SerializeField] TextMeshProUGUI musicArtistDisplay;
    [SerializeField] Animator anim;

    public void DisplayMusic(Music music)
    {
        musicNameDisplay.text = music.musicName;
        musicArtistDisplay.text = music.musicArtist;
        anim.SetTrigger("display");
    }

    public void HideMusic()
    {
        musicDisplay.SetActive(false);
    }
}
