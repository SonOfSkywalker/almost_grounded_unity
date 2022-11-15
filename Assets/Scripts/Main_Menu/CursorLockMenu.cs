using UnityEngine;

public class CursorLockMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
      Cursor.visible = true; // Showing the cursor
      Cursor.lockState = CursorLockMode.None; //  Unlocking the cursor
    }
}
