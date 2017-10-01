using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public LayerMask interactable;
    public Interactable focus;

    public Texture2D mainCursor;
    public Texture2D attackCursor;

    public static bool basicAttack;
    public static bool secondaryAttack;

    Camera cam;
    PlayerMovement movement;

    private void Start()
    {
        cam = Camera.main;
        movement = GetComponent<PlayerMovement>();
        Cursor.SetCursor(mainCursor, new Vector2(mainCursor.width / 2, mainCursor.height / 2), CursorMode.Auto);
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //If you are currently hovering over UI
            return;

        basicAttack = Input.GetMouseButton(0);
        secondaryAttack = Input.GetMouseButton(1);

        bool stopWalking = Input.GetKey(KeyCode.LeftShift);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, interactable))
        {
            if (secondaryAttack || basicAttack)
            {
                if (!stopWalking)
                    movement.MoveToPoint(hit.point);

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
            Cursor.SetCursor(attackCursor, new Vector2(attackCursor.width / 2, attackCursor.height / 2), CursorMode.Auto);
        }
        else if (Physics.Raycast(ray, out hit, 100, movementMask))
        {
            if (secondaryAttack || basicAttack)
            {
                if (!stopWalking)
                    movement.MoveToPoint(hit.point);

                RemoveFocus();
            }
            Cursor.SetCursor(mainCursor, new Vector2(mainCursor.width / 2, mainCursor.height / 2), CursorMode.Auto);
        }

        if (stopWalking)
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
