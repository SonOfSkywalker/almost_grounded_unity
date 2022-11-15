using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A standard platform

public class SimplePlatform : MonoBehaviour
{
    private float Height;
    

    void Awake(){

      // Add a Mesh Collider if there is not any
      if (gameObject.GetComponent<MeshCollider>() == null){
        gameObject.AddComponent<MeshCollider>();
      }
      // Set the mesh collider on trigger mode
      gameObject.GetComponent<MeshCollider>().convex = true;
      gameObject.GetComponent<MeshCollider>().isTrigger = true;

    }


    void Start(){
      Height = transform.position.y;
    }
}
