using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimation : MonoBehaviour
{



    void Start()
    {
      StartCoroutine(Animation());
    }


    IEnumerator Animation(){

      yield return new WaitForSecondsRealtime(4);

      FadeOnLoad.Instance.FadeToScene("Main_Menu");
    }
}
