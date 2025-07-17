using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Target and sensitivity")]
    [SerializeField] private Transform playerHead;
    [SerializeField] private float sensitivityX;
    [SerializeField] private float sensitivityY;

    [Header("Clamp")]
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private Vector2 inputLook;
    private float xRotation;
    [SerializeField] private Transform orientation;

    public void OnLook(InputAction.CallbackContext context)
    {
        inputLook = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    private void LateUpdate()
    {
        float mouseX = inputLook.x * sensitivityX;
        float mouseY = inputLook.y * sensitivityY;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);

        transform.position = playerHead.position;
        transform.rotation = Quaternion.Euler(xRotation, transform.eulerAngles.y + mouseX, 0f);

        if(orientation != null)
        {
            orientation.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
        }
    }
}
