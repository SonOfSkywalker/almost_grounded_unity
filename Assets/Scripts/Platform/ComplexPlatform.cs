using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Platform which moove on the x Axis
public class ComplexPlatform : MonoBehaviour
{
    private float Height;
    private int i;
    

    void Start(){
      i=0;
      Height = transform.position.y;
    }



    void Update(){
    if(i<500)
    {
      Vector3 targetPosition = new Vector3(transform.position.x+ 16*0.1f, Height, transform.position.z);
      i++;
      transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);}
    if(i>=500&&i<1000)
    {
      i++;
    }

    if(i>=1000 && i < 1500)
    {

      Vector3 targetPosition = new Vector3(transform.position.x- 16*0.1f, Height,transform.position.z);
      i++;
      transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);}

          if(i>=1500&&i<2000)
    {
      i++;
    }

    if(i==2000)
    {
      i=0;
    }
}



  }
