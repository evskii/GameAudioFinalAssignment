using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPlayerMouseLook : MonoBehaviour
{
    private FPSPlayerInputActions playerInputActions;
    [SerializeField] private float mouseSensitivity = 100f;

    private Vector2 look;

    private float xRotation;

    private Transform playerBody;
    

    private void Start() {
        playerInputActions = GetComponentInParent<FPSPlayerMovementCharacterController>().playerInputActions;
        playerBody = transform.parent;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        look = playerInputActions.Player.Look.ReadValue<Vector2>();
        
        var mouseX = look.x * mouseSensitivity * Time.deltaTime;
        var mouseY = look.y * mouseSensitivity * Time.deltaTime;
    
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

}
