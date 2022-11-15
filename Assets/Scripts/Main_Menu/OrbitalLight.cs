using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMathTools;

public class OrbitalLight : MonoBehaviour
{

    [SerializeField] Transform Target; // The target to track

    public float Speed = 5f;

    public float Rho = 120f;
    private float Phi = 20f;
    private float Theta = 90f;

    private float Phi_Rad ;
    private float Theta_Rad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Phi_Rad = Phi * Mathf.Deg2Rad;
      Theta_Rad = Theta * Mathf.Deg2Rad;

      Phi += Speed;

      Vector3 Target_Position = Target.position + CoordConvert.SphericalToCartesian(new Spherical(Rho, Phi_Rad, Theta_Rad)); // Compute target position for the light
      Target_Position.y += 100f;
      Vector3 Smoothed_Position = Vector3.Lerp(Target.position, Target_Position, 0.2f); // Makes the light movement smoother
      transform.position = Smoothed_Position; // Setting light position
      transform.LookAt(Target.position);
    }
}
