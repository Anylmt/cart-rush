using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private JoystickInput _joyStickInput;
    [SerializeField] private Transform cartTransform;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        _joyStickInput = GetComponent<JoystickInput>();
    }

    void Update()
    {
        if (GameManager.CurrentState == Enums.GameState.GameStarted)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(_joyStickInput.InputValue.x, 0, _joyStickInput.InputValue.z);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.33f, 4.33f), transform.position.y, Mathf.Clamp(transform.position.z, cartTransform.position.z - 4f, cartTransform.position.z + 5f));
        }
    }
}
