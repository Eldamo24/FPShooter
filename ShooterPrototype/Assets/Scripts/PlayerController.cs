using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Ground check")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;

    [Header("Orientation")]
    [SerializeField] private Transform orientation;

    private Rigidbody rb;
    private Vector2 inputMove;
    [SerializeField] private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded)
        {
            Jump();
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {

    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, .2f, groundMask);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = orientation.forward * inputMove.y + orientation.right * inputMove.x;
        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, .2f);
    }
}
