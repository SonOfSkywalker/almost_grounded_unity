using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBar : MonoBehaviour
{

    public Slider slider;




    public void SetMaxValue(float Max_Jump_Force){
      slider.maxValue = Max_Jump_Force;
    }

    public void SetJumpBar(float Jump_Force){
      slider.value = Jump_Force;
    }


}
