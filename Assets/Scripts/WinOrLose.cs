using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLose : MonoBehaviour
{
    public static bool isVictory = false;
    public static bool isGameOver = false;


    public static WinOrLose Instance;


    void Awake()
    {
      if (Instance == null){
        Instance = this;
      }
      else{
        Destroy(gameObject);
      }

      isVictory = false;
      isGameOver = false;
    }

    void Update()
    {
        if (isVictory){
          isVictory = false;
          if (AudioManager.Instance != null){
            AudioManager.Instance.PauseAll();
            AudioManager.Instance.Play("Victory");
          }
          FadeOnLoad.Instance.FadeToScene("Victory");
        }
        if (isGameOver){
          isGameOver = false;
          if (AudioManager.Instance != null){
            AudioManager.Instance.PauseAll();
            AudioManager.Instance.Play("GameOver");
          }
          FadeOnLoad.Instance.FadeToScene("GameOver");
        }
    }
}
