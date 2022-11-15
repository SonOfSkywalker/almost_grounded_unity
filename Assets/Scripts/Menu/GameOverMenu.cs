using UnityEngine;
using PlayerInput;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{

  // Update is called once per frame
  void Start()
  {

  }


  public void MainMenu(){
    if (AudioManager.Instance != null){
      AudioManager.Instance.PauseAll();
      AudioManager.Instance.Play("BackClick");
      AudioManager.Instance.PlayTheme();

    }

    FadeOnLoad.Instance.FadeToScene("Main_Menu");
  }




}
