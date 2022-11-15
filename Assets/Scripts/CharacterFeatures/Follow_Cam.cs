using MyMathTools;
using UnityEngine;
using PlayerInput;

// DESCRIPTION :
// Main script for Third Person View
// Following a target object (the character)
// APPLY TO Camera


public class Follow_Cam : MonoBehaviour
{


  [SerializeField] Transform Target; // The target to track

  [SerializeField]  float Sensitivity = 3; // Sensitivity of the mouse's movements



  [SerializeField] float Normal_Rho = 100f; // Non-running rho
  [SerializeField] float Running_Rho = 120f; // Allow a little zoom when running


  [SerializeField] float Phi_Start = 90 ;

  [SerializeField] float Theta_Start = -45;
  [SerializeField] float Theta_Max = -15 ;
  [SerializeField] float Theta_Min = -75 ;

  private Vector2 Rot; // Contains the processed data to rotate using the mouse's movements
  [Range(0.005f, 1f)] [SerializeField] float Smoothness_Cam = 0.1f; //  Camera movements Smoothness


  private float Rho;
  private float Phi;
  private float Theta;

  private float Phi_Rad;
  private float Theta_Rad;


    // Start is called before the first frame update
    void Start()
    {
      Rho = Normal_Rho;
      Phi = Phi_Start;
      Theta = Theta_Start ;
    }

    // Update is called once per frame
    void Update()
    {
      MoveCamera();
    }

    private void MoveCamera(){
        if (!(PauseMenu.GameIsPaused)){
          // Rotating camera horizontally when mouse is moving
          Rotate();

          // Discrete zoom when Running
          Zoom();

          // Front camera enabled if E pressed
          FrontCam();

          // Making the camera following the object
          Follow();
      }
    }

    // Making the camera following the object
    private void Follow(){
      Phi_Rad = Phi * Mathf.Deg2Rad;
      Theta_Rad = Theta * Mathf.Deg2Rad;


      Vector3 Target_Position = Target.position + CoordConvert.SphericalToCartesian(new Spherical(Rho, Phi_Rad, Theta_Rad)); // Compute target position for the camera
      Vector3 Smoothed_Position = Vector3.Lerp(Target.position, Target_Position, Smoothness_Cam); // Makes the camera movement smoother
      transform.position = Smoothed_Position; // Setting camera position
      transform.LookAt(Target.position); // Put the target object in the center of the frame
    }

    // Discrete zoom when Running, basically switching from normal_rho to running_rho
    private void Zoom(){

      if(PlayerInput.Getter.Sprint()){
        Rho = Mathf.Lerp(Rho,Running_Rho,0.05f); // Switching to running_rho
      }
      else{
        Rho = Mathf.Lerp(Rho,Normal_Rho,0.05f); // Switching to normal_rho
      }
    }

    // Rotating camera horizontally when mouse is moving
    private void Rotate(){
      Rot -= PlayerInput.Getter.Mouse() * Sensitivity; // Get rotation to be made

      Phi = (Phi_Start + Rot.x);
      Theta = Mathf.Clamp((Theta_Start + Rot.y), Theta_Min,Theta_Max);

    }

    // Placing camera in front of character if E pressed
    private void FrontCam(){
      if(PlayerInput.Getter.FrontCam()){
        Phi =Phi+180;// Switching to front cam
      }

    }
}
