using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftPlatform : MonoBehaviour
{
    private float Height;
    private int i;
    private int max;






    void Start(){
      i=0;
      max = 2000;
      Height = transform.position.y;
    }



    void Update(){


      if(i<max/4)
      {
        Vector3 targetPosition = new Vector3(transform.position.x, Height, transform.position.z- 2*0.1f);
        i++;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);
      }

      if ( (i >= max/4) && (i < max/2) )
      {
        i++;
      }

      if ( (i>=max/2) && (i < 3*max/4) )
      {

        Vector3 targetPosition = new Vector3(transform.position.x, Height, transform.position.z+ 2*0.1f);
        i++;
        transform.position = Vector3.Lerp(transform.position, targetPosition, .5f);
      }

      if ( (i>=3*max/4) && (i<max) )
      {
        i++;
      }

      if(i>=max)
      {
        i=0;
      }
    }



}
