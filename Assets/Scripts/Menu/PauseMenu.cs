using UnityEngine;
using PlayerInput;
using UnityEngine.SceneManagement;


// Inspired by https://www.youtube.com/watch?v=JivuXdrIHK0

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.Getter.PauseToggle()){
          if (GameIsPaused){

            Resume();
          }

          else{
            Pause();
          }

        }
    }


    public void Resume(){
      if (AudioManager.Instance != null){
        AudioManager.Instance.Play("ButtonClick");
      }
      PauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
    }



    void Pause(){
      PauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void MainMenu(){
      Resume();
      if (AudioManager.Instance != null){
        AudioManager.Instance.Play("BackClick");
      }
      FadeOnLoad.Instance.FadeToScene("Main_Menu");
    }




}
