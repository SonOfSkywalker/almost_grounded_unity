using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInput;

// DESCRIPTION :
// All functions to make the character moves

namespace Char_Mvt{

  public static class CM_Check
  {
    // Checks if the feet are near a floor object
    public static bool Floor_Check(Transform FeetTransform, LayerMask FloorMask, float Radius){
      return Physics.CheckSphere(FeetTransform.position, Radius, FloorMask);
    }

    // Allows jumping if Jump Key is pressed and if floor check is okay
    public static bool Allow_Jump(Transform FeetTransform, LayerMask FloorMask){
      if (CM_Check.Floor_Check(FeetTransform, FloorMask, .1f)){
        Character_Movement.Instance.AerialJump = true;
        return PlayerInput.Getter.Jump();
      }

      else{
        if (Character_Movement.Instance.AllowDoubleJump){

          if (Character_Movement.Instance.AerialJump){
            if (PlayerInput.Getter.Jump()){
              Character_Movement.Instance.AerialJump = false;
              return PlayerInput.Getter.Jump();
            }

            else{
              return false;
            }
          }
      }
    }

      return false;
  }
}


  public static class CM_Walk
  {
    public static void Action(Transform Object, Rigidbody Body, float Speed, Transform FeetTransform, LayerMask FloorMask){
      Vector3 MoveVector = Object.TransformDirection(PlayerInput.Getter.Arrows()) * Speed;


      Body.velocity = new Vector3(MoveVector.x, Body.velocity.y, MoveVector.z);
    }

    // Returns the correct speed (running or running) by checking if sprint key is pressed
    public static float Get_Correct_Speed(float Current_Speed, float Normal_Speed, float Running_Speed){
      if(PlayerInput.Getter.Sprint()){
        return Running_Speed;
      }
      else{
        return Normal_Speed;
      }
    }

    // Makes the character walk according to input
    public static float Process(Transform Object, Rigidbody Body, float Current_Speed, float Normal_Speed, float Running_Speed, Transform FeetTransform, LayerMask FloorMask){
      float Target_Speed = CM_Walk.Get_Correct_Speed(Current_Speed, Normal_Speed, Running_Speed);
      float Speed = Mathf.Lerp(Current_Speed, Target_Speed, 0.05f);
      CM_Walk.Action(Object, Body, Speed, FeetTransform, FloorMask);
      return Speed;
    }

  }

  public static class CM_Jump
  {
    // Jump action
    public static void Action(Rigidbody Body, float Jump_Force){

      Body.AddForce(Vector3.up * Jump_Force, ForceMode.Impulse);

    }

    // Makes the character jump if allowed
    public static void Process(Rigidbody Body, float Jump_Force, Transform FeetTransform, LayerMask FloorMask){
      if (!(Character_Movement.Instance.AerialJump)){
        if (CM_Check.Allow_Jump(FeetTransform, FloorMask)){
          CM_Jump.Action(Body, Jump_Force);
        }
      }
      else{
        if (CM_Check.Allow_Jump(FeetTransform, FloorMask)){
          Body.velocity = new Vector3(Body.velocity.x, 0, Body.velocity.z);
          CM_Jump.Action(Body, Jump_Force);
        }
      }


    }

  }

  public static class CM_Turn
  {
    public static Vector2 Get_Rotation(Vector2 Rot, float Sensitivity){
      return Rot - PlayerInput.Getter.Mouse() * Sensitivity;
    }

    // Makes the character rotate according to mouse input
    public static Vector2 Process(Transform Object, Vector2 Rot, float Sensitivity, float Smoothness_Rot){
      Rot = CM_Turn.Get_Rotation(Rot, Sensitivity);
      Object.rotation = Quaternion.Slerp(Object.rotation, Quaternion.Euler(0f, -Rot.x, 0f), Smoothness_Rot);
      return Rot;
    }
  }






}
