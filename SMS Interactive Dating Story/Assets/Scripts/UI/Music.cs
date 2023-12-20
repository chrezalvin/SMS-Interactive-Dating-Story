using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Music/Music")]
public class Music: ScriptableObject
{
    public string musicName = "";
    public string musicArtist = "";
    public AudioClip musicClip;
}
