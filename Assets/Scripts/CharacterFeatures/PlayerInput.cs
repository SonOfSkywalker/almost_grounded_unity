
using UnityEngine;


namespace PlayerInput{
  public static class Getter
  {
    // ZQSD / WASD or arrows
    public static Vector3 Arrows(){
      return new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    // Mouse
    public static Vector2 Mouse(){
      return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    // Left Shift
    public static bool Sprint(){
      return Input.GetKey(KeyCode.LeftShift);
    }

    // Space
    public static bool Jump(){
      return Input.GetKeyDown(KeyCode.Space);
    }

    // FrontCam Activation
    public static bool FrontCam(){
        return Input.GetKey(KeyCode.E);
    }

    // Pause or Resume Game
    public static bool PauseToggle(){
      return Input.GetKeyDown(KeyCode.Escape);
    }



    }
  }
