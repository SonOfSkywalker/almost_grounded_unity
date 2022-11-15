using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
      Quaternion StartOr = Quaternion.AngleAxis(45, Vector3.up);

      transform.rotation = StartOr;
  }

  // Update is called once per frame
  void Update()
  {
      // Rotation de durée infinie
      Quaternion Rot1 = Quaternion.AngleAxis(75*Time.deltaTime, transform.up);
      Quaternion Rot2 = Quaternion.AngleAxis(75*Time.deltaTime, transform.right);
      transform.rotation = Rot1 * Rot2* transform.rotation;


  }
}
