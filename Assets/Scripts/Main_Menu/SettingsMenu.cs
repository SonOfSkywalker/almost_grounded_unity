using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public Slider slider;

    void Awake(){
      float value;
      AudioMixer.GetFloat("Volume", out value);
      value = Mathf.Clamp(value, -40f, 10f) ;
      if (slider != null){
        slider.value = value;
      }

    }


    public void SetVolume(float Volume){
      if (Volume < - 38f){
        Volume = -80f;
      }
      AudioMixer.SetFloat("Volume", Volume);
    }

    public void Back(){
        AudioManager.Instance.Play("BackClick");
    }
}
