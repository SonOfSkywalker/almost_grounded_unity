using UnityEngine;

using Char_Mvt;

// Inspired by : https://www.youtube.com/watch?v=b1uoLBp2I1w

// DESCRIPTION :
// Main script to control the character's movements
// Using Character_Actions.cs to make all the movements
// APPLY TO Character object

public class Character_Movement : MonoBehaviour
{
  public static Character_Movement Instance {get; private set;}

    private Vector2 Rot;

    private Rigidbody Body; // RigidBody of the character

    [SerializeField]  float Normal_Speed = 5;
    [SerializeField]  float Running_Speed = 12;
    private  float Current_Speed;


    [SerializeField]  float Sensitivity = 3;
    [SerializeField]  float Jump_Force = 15;
    [SerializeField] float Max_Jump_Force = 120;

    [Range(0.005f, 1f)] [SerializeField] float Smoothness_Rot = 0.2f;

    [SerializeField] private Transform FeetTransform; // Create a empty object at the bottom of the object
    [SerializeField] private LayerMask FloorMask; // Create a floor layer and set any floor to this layer + the feet to this layer

    public bool AllowDoubleJump = false;
    public bool AerialJump = false;

    private void Awake(){
      if (Instance == null){
        Instance = this;
      }
      else{
        Destroy(gameObject); // make sure that there is only one character instance
      }
    }



    void Start(){
      Body = GetComponent<Rigidbody>();

      Current_Speed = Normal_Speed;
    }

    void Update(){

      if (!(PauseMenu.GameIsPaused)){
        // Moving the object
        Move();
      }


      if (transform.position.y < -20){
        WinOrLose.isGameOver = true;
      }






      }


    private void Move(){
      // Moving object according to ZQSD / WASD
      Current_Speed = Char_Mvt.CM_Walk.Process(transform, Body, Current_Speed, Normal_Speed, Running_Speed, FeetTransform, FloorMask);



      // Jumping when Space pressed
      Char_Mvt.CM_Jump.Process(Body, Jump_Force, FeetTransform, FloorMask);

      // Rotating object when mouse is moving
      Rot = Char_Mvt.CM_Turn.Process(transform, Rot, Sensitivity, Smoothness_Rot);

    }


    public void AddJumpForce(float x){
      Jump_Force += x;
      if (Jump_Force > Max_Jump_Force){
        Jump_Force = Max_Jump_Force;
      }
    }

    public float GetJumpForce(){
      return Jump_Force;
    }

    public float GetMaxJumpForce(){
      return Max_Jump_Force;
    }


}
