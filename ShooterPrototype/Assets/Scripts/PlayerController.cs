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

    [Header("Animator")]
    [SerializeField] private Animator anim;
    private float currentSpeed = 0f;
    [SerializeField] private float smoothTime = 0.1f;

    [SerializeField] private Camera playerCamera;

    [Header("Shoot variables")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;
    private float nextFireTime;
    private bool isShooting;



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
        if (context.started)
        {
            isShooting = true;
        }
        if (context.canceled)
        {
            isShooting = false;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PauseGame();
        }
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, .2f, groundMask);
        if (isShooting && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        float targetSpeed = horizontalVelocity.magnitude;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime / smoothTime);
        anim.SetFloat("Speed", currentSpeed);
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

    private void Shoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        GameObject bullet = Instantiate(bulletPrefab, ray.origin, Quaternion.identity);
        Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
        rbBullet.velocity = ray.direction * bulletSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, .2f);
    }
}
