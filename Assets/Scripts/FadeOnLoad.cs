using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOnLoad : MonoBehaviour
{

    public Animator myAnimator;
    public int Scene2Load;
    public string Scene2LoadString;
    public bool isIndex = false;

    public static FadeOnLoad Instance;


    void Awake(){
      if (Instance == null){
        Instance = this;
      }
      else{
        Destroy(gameObject);
      }
    }

    void Update(){

    }


    public void FadeToScene (int SceneIndex){
      isIndex = true;
      Scene2Load = SceneIndex;
      myAnimator.SetTrigger("Fade_Out");

    }

    public void FadeToScene (string SceneName){
      isIndex = false;
      Scene2LoadString = SceneName;
      myAnimator.SetTrigger("Fade_Out");

    }

    public void OnFadeComplete(){
      if (isIndex){
        SceneManager.LoadScene(Scene2Load);
      }
      else{
        SceneManager.LoadScene(Scene2LoadString);
      }

    }
}
