using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement moveController = null;
    [SerializeField] private float movementSpeed = 40f;

    private float movementXAxis = 0f;
    private bool jump = false;
    private bool crouch = false;
    
    private void Awake()
    {
        moveController = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        moveController.Move(movementXAxis, crouch, jump);
        jump = false;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        movementXAxis = context.ReadValue<Vector2>().x * movementSpeed * Time.deltaTime;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        jump = true;
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        crouch = context.ReadValueAsButton();
    }
}
