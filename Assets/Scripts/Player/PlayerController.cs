using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] 
    public float speed;
    private Vector2 movementInput;
    public float jumpForce;
    public LayerMask groundLayerMask;

    [Header("Look")] 
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;

    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    void Move()
    {
        Vector3 dir = transform.forward * movementInput.y + transform.right * movementInput.x;
        dir *= speed;
        dir.y = _rigidbody.velocity.y;
        
        _rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        camXRot += mouseDelta.y * lookSensitivity;
        camXRot = Mathf.Clamp(camXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camXRot, 0, 0);
        
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMove(InputAction. CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            movementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            movementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    public bool IsGrounded()
    {
        Ray ray = new Ray(transform.position + transform.up * 0.01f, Vector3.down);
        if(Physics.Raycast(ray, 1.5f, groundLayerMask))
        {
            return true;
        }
        return false;
    }
}
