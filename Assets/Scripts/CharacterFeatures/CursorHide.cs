using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DESCRIPTION :
// Allows to lock and hide the mouse pointer
// When we will run the game, the pointer will nor go out of the screen
// APPLY TO empty object

public class CursorHide : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!(PauseMenu.GameIsPaused)){
          Cursor.visible = false; // Hiding the cursor
          Cursor.lockState = CursorLockMode.Locked; //  Locking the cursor inside the game frame
        }
        else{
          Cursor.visible = true; // Showing the cursor
          Cursor.lockState = CursorLockMode.None; //  Unlocking the cursor
        }
    }
}
