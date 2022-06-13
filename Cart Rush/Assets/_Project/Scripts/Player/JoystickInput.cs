using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    private Vector3 inputValue = Vector3.zero;
    public Vector3 InputValue => inputValue;

    private void Update()
    {
        if (GameManager.CurrentState == Enums.GameState.GameStarted)
        {
            if (Input.GetMouseButton(0))
            {
                inputValue = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            }
                
            if (Input.GetMouseButtonUp(0))
            {
                inputValue = new Vector3(0, 0, 0.3f);
            }
            
        }
        
    }
}
