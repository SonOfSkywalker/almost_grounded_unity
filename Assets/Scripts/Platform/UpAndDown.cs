using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Platform which moove on the Y-Axis

public class UpAndDown : MonoBehaviour
{
    private float Height;
    private int i;
    private int max;


    void Start(){
      max = 500;
      i=0;
      Height = transform.position.y;
    }



    void Update(){
  
    if(i<max/4)
    {
      Vector3 targetPosition = new Vector3(transform.position.x, Height+ 16*0.08f, transform.position.z);
      i++;
      transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
    }

    if(i>=max/4 && i<max/2)
    {
      i++;
    }

    if(i>=max/2 && i < 3*max/4)
    {

      Vector3 targetPosition = new Vector3(transform.position.x, Height- 16*0.08f,transform.position.z);
      i++;
      transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
    }

    if(i>=3*max/4 && i<max)
    {
      i++;
    }

    if(i >= max)
    {
      i=0;
    }
}



  }
