using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] //to show up in inspector
public class Sound
{
    public string name; //name of the sound object
    public AudioClip clip; //the sound clip to play
    public bool loop;
    public AudioMixerGroup mixer;
    [HideInInspector] //hides this from showing up in the inspector
    public AudioSource source;
}
