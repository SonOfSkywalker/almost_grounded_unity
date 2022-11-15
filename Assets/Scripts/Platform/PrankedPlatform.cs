using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Platform which appear and disappear
public class PrankedPlatform : MonoBehaviour
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
      
    if(i<3*max/4)
    {
      Vector3 targetPosition = new Vector3(transform.position.x, Height, transform.position.z);
      i++;
      transform.position = Vector3.Lerp(transform.position, targetPosition, 5f);}


    if(i>=3*max/4 && i < max)
    {

      Vector3 targetPosition = new Vector3(transform.position.x, Height-10, transform.position.z);
      i++;
      transform.position = Vector3.Lerp(transform.position, targetPosition, 5f);}

    if(i >= max)
    {
    	i = 0;
    }
}
}
