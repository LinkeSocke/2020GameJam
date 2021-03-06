﻿using System.Collections;
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
    [SerializeField] private float interactionDistance = 1.2f;
    [SerializeField] private float interactionOffset = 0f;
    [SerializeField] private LayerMask whatIsInteractable;

    private List<Keycard> keycards = new List<Keycard>();

    [SerializeField] private Transform flashlight = null;
    [SerializeField] private float angleOffset = -90f;
    private bool facingRight = false;
    private Camera cam;

    [SerializeField] private Animator anim = null;
    private const string MOVEMENT_STATE = "MovementState";

    [SerializeField] private Transform crouchedLightPosition = null;
    [SerializeField] private Transform standingLightPosition = null;

    private bool isGrounded = false;

    private void Awake()
    {
        moveController = GetComponent<PlayerMovement>();
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            anim.SetInteger(MOVEMENT_STATE, 4);
        }
        else
        {
            if (movementXAxis != 0)
            {
                if (crouch)
                {
                    anim.SetInteger(MOVEMENT_STATE, 3);
                }
                else
                {
                    anim.SetInteger(MOVEMENT_STATE, 1);
                }
            }
            else
            {
                if (crouch)
                {
                    anim.SetInteger(MOVEMENT_STATE, 2);
                }
                else
                {
                    anim.SetInteger(MOVEMENT_STATE, 0);
                }
            }
        }
        moveController.Move(movementXAxis, crouch, jump, ref isGrounded);
        jump = false;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        movementXAxis = context.ReadValue<Vector2>().x * movementSpeed * Time.deltaTime;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        jump = true;
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        crouch = context.ReadValueAsButton();
        if (crouch)
        {
            flashlight.transform.position = crouchedLightPosition.position;
        }
        else
        {
            flashlight.transform.position = standingLightPosition.position;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        IInteractable interactable = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector3(transform.position.x, transform.position.y + interactionOffset, transform.position.z), interactionDistance, whatIsInteractable);
        if (colliders == null || colliders.Length <= 0) return;

        float leastDistance = Vector3.Distance(transform.position, colliders[0].transform.position);
        foreach(Collider2D col in colliders)
        {
            float curDistance = Vector3.Distance(transform.position, col.transform.position);

            if (curDistance >= leastDistance)
            {
                leastDistance = curDistance;
                interactable = col.gameObject.GetComponent<IInteractable>();
            }
        }

        if(interactable != null)
        {
            interactable.Interact();
        }
    }

    public void Look(InputAction.CallbackContext context)
    {

        var pos = context.action.ReadValue<Vector2>();
        var flashlightPos = cam.WorldToScreenPoint(flashlight.transform.position);
        var dir = pos - new Vector2(flashlightPos.x, flashlightPos.y);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;

        var bodyPost = cam.WorldToScreenPoint(transform.position);
        var bodyDir = pos - new Vector2(bodyPost.x, bodyPost.y);

        if (bodyDir.x > 0 && facingRight)
        {
            Flip();
        } else if(bodyDir.x < 0 && !facingRight)
        {
            Flip();
        }

        flashlight.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public List<Keycard> GetKeycards()
    {
        return keycards;
    }

    public void AddKeycard(Keycard keycard)
    {
        keycards.Add(keycard);
        UIManager.Instance.AddKeycardToUI(keycard);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + interactionOffset, transform.position.z), interactionDistance);
    }
}
