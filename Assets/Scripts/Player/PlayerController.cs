using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement moveController = null;
    [SerializeField] private float movementSpeed = 40f;

    private float movementXAxis = 0f;
    [SerializeField] private bool jump = false;
    [SerializeField] private bool crouch = false;
    [SerializeField] private float interactionDistance = 1.2f;
    [SerializeField] private LayerMask whatIsInteractable;

    private List<Keycard> keycards = new List<Keycard>();

    Vector2 lookPos = Vector2.zero;

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

    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        IInteractable interactable = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionDistance, whatIsInteractable);
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
        var test = Camera.main.WorldToScreenPoint(transform.position);
        lookPos = pos - new Vector2(test.x, test.y);
    }

    public List<Keycard> GetKeycards()
    {
        return keycards;
    }

    public void AddKeycard(Keycard keycard)
    {
        keycards.Add(keycard);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
        Gizmos.DrawRay(transform.position, lookPos);
    }
}
