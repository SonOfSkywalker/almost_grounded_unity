using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Position = transform.position;
        transform.position = new Vector3(Position.x + (Mathf.PingPong(Time.time, 10) - 1)/8, Position.y, Position.z);
    }
}
