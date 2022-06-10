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
        inputValue = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
    }
}
