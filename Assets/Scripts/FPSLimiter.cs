using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inspired by https://answers.unity.com/questions/1366716/how-to-liimit-fps.html

public class FPSLimiter : MonoBehaviour
 {

     public int target = 30;

     void Awake()
     {
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = target;
     }

     void Update()
     {
       if(Application.targetFrameRate != target)
       {
             Application.targetFrameRate = target;
       }
     }
 }
