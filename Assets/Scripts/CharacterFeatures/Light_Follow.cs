using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Follow : MonoBehaviour
{

    [SerializeField] float Height_Offset = 10f;
    [SerializeField] Transform Target;


    void Update()
    {
      transform.position = new Vector3( Target.position.x + 50f, Target.position.y + Height_Offset , Target.position.z );
    }
}
