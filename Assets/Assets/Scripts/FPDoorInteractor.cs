using UnityEngine;

public class FPDoorInteractor : MonoBehaviour
{
    [Header("RaycastSettings")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxInteractDistance = 3f;
    [SerializeField] private LayerMask interactableLayers = -1;

    [Header("Input")]
    [SerializeField] private KeyCode interactKey = KeyCode.Mouse0;

    private void Awake()
    {
        if (playerCamera == null)
        {
            playerCamera = GetComponent<Camera>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            InteractWithDoor();
        }
    }

    private void InteractWithDoor() 
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, maxInteractDistance, interactableLayers))
        {
            DoorController door = hit.collider.GetComponent<DoorController>();

            if (door != null)
            {
                door.ToggleDoor();
            }
        }
    }
}
