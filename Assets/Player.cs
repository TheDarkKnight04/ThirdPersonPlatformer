using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Transform cameraTransform;

    private Rigidbody rb;

    private bool isGrounded = false;
    private bool canDoubleJump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        if (cameraTransform == null)
        {
            Debug.Log("Camera Transform not Assigned!");
            return;
        }
        
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
        
        if (isGrounded)
        {
            Vector3 moveDirection = camForward * direction.z + camRight * direction.x;
            rb.AddForce(speed * moveDirection);
        }
        

        if (direction.y > 0)
            if(isGrounded)
            {
                Jump();
                isGrounded = false;
            }
            else if(canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
    }

    private void Jump()
    {
        Vector3 jumpForceVector = Vector3.up * jumpHeight;
        rb.AddForce(jumpForceVector, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
