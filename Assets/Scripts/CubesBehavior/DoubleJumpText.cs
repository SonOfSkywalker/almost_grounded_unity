using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoubleJumpText : MonoBehaviour
{

    public TextMeshProUGUI text;

    void Update()
    {
      if(Character_Movement.Instance.AllowDoubleJump){
        text.color = new Color(0,0,0,0.9f);
      }
      else{
              text.color = new Color(0,0,0,0.2f);
      }
    }
}
