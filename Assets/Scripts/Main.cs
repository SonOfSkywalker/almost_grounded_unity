using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    Character_Movement Character;
    public JumpBar JumpBar;


    // Start is called before the first frame update
    void Start()
    {
        Character = Character_Movement.Instance;
        JumpBar.SetMaxValue(Character.GetMaxJumpForce());
    }

    // Update is called once per frame
    void Update()
    {
      JumpBar.SetJumpBar(Character.GetJumpForce());
    }
}
