using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public LayerMask interactable;
    public Interactable focus;

    public static bool basicAttack;
    public static bool secondaryAttack;

    Camera cam;
    PlayerMovement movement;

    private void Start()
    {
        cam = Camera.main;
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //If you are currently hovering over UI
            return;

        basicAttack = Input.GetMouseButton(0);
        secondaryAttack = Input.GetMouseButton(1);

        bool stopWalking = Input.GetKey(KeyCode.LeftShift);

        if (secondaryAttack || basicAttack)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, interactable))
            {
                if(!stopWalking)
                    movement.MoveToPoint(hit.point);

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
            else if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                if (!stopWalking)
                    movement.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        else if(stopWalking)
        {
            movement.agent.SetDestination(transform.position);
        }
    }
    
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
            movement.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();

        focus = null;
        movement.StopFollowingTarget();
    }
}
