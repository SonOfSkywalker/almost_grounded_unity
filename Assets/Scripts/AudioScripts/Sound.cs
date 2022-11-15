using UnityEngine.Audio;
using UnityEngine;

// Inspired by https://www.youtube.com/watch?v=6OT43pvUyfY
[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;

    [Range(0f,1f)]
    public float Volume;

    public bool Loop;

    [HideInInspector]
    public AudioSource Source;
}
