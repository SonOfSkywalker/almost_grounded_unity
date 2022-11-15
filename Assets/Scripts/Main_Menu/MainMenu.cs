using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play(){
      AudioManager.Instance.Play("ButtonClick");
      FadeOnLoad.Instance.FadeToScene(SceneManager. GetActiveScene().buildIndex + 1);

    }

    public void Settings(){
        AudioManager.Instance.Play("ButtonClick");
    }

    public void Credits(){
        AudioManager.Instance.Play("ButtonClick");
    }

    public void Quit(){

      Debug.Log("QUIT");
      Application.Quit();
    }


}
