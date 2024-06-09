using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    public InputAction playerControls;
    public Rigidbody2D rb;
    public float moveSpeed = 1;

    private Vector2 moveDirection = Vector2.zero;

    void OnEnable() {
        playerControls.Enable();
    }

    void OnDisable() {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update() {
        moveDirection = playerControls.ReadValue<Vector2>();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
