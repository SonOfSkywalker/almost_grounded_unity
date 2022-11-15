using UnityEngine.Audio;
using UnityEngine;
using System;

// Inspired by https://www.youtube.com/watch?v=6OT43pvUyfY

public class AudioManager : MonoBehaviour
{
  public AudioMixerGroup MainMixer;
  public Sound[] Sounds;
  public static AudioManager Instance;

  void Awake(){
    DontDestroyOnLoad(gameObject);

    if (Instance == null){
      Instance = this;
    }
    else{
      Destroy(gameObject);
      return;
    }

    foreach(Sound v_Sound in Sounds){
      v_Sound.Source = gameObject.AddComponent<AudioSource>();
      v_Sound.Source.clip = v_Sound.Clip;
      v_Sound.Source.volume = v_Sound.Volume;
      v_Sound.Source.outputAudioMixerGroup = MainMixer;
      v_Sound.Source.loop = v_Sound.Loop;
    }
  }

  void Start(){
    // Main Theme
    PlayTheme();
  }

  void Update(){
    // We decrease the pitch of the Theme Song if the game is paused
    ProcessThemeOnPause();
  }

  public void Play(string Name){
    Sound v_Sound = Array.Find(Sounds, Sound => Sound.Name == Name);
    if (v_Sound == null){
      Debug.Log("Could not find " + Name + " in AudioManager");
      return;
    }
    v_Sound.Source.Play();
  }

  public void PauseAll(){
      foreach(Sound v_Sound in Sounds){
          v_Sound.Source.Pause();
      }
  }

  public void PauseTheme(){
    Sound v_Sound = Array.Find(Sounds, Sound => Sound.Name == "Theme");
    if (v_Sound == null){
      Debug.Log("Could not find Theme in AudioManager");
      return;
    }
    v_Sound.Source.Pause();
  }

  public void PlayTheme(){
    Sound v_Sound = Array.Find(Sounds, Sound => Sound.Name == "Theme");
    if (v_Sound == null){
      Debug.Log("Could not find Theme in AudioManager");
      return;
    }
    v_Sound.Source.Play();
  }

  void ProcessThemeOnPause(){
    Sound Theme = Array.Find(Sounds, Sound => Sound.Name == "Theme");
    if (PauseMenu.GameIsPaused){

      Theme.Source.pitch = Mathf.Lerp(Theme.Source.pitch, .5f, 0.02f);
    }
    else{
      Theme.Source.pitch = Mathf.Lerp(Theme.Source.pitch, 1f, 0.04f);
    }
  }


}
