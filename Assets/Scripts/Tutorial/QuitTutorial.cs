using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTutorial : MonoBehaviour
{
    public void QuitTuto(){
        FadeOnLoad.Instance.FadeToScene("Level 1");
    }
}
