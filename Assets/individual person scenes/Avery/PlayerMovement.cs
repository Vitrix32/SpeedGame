using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public Vector2 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    public float moveSpeed = 1f;
    public float jumpStrength = 1f;
    public float coyoteTime = 0.1f;
    public float jumpBufferTime = 0.2f;

    private float moveDir = 0f;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    private bool jumping;

    void OnJump(InputValue value) {
        float v = value.Get<float>();
        if (v == 0f) {
            return;
        }
        jumpBufferCounter = jumpBufferTime;
    }

    void OnMove(InputValue value) {
        moveDir = value.Get<float>();
    }

    void Update() {
        jumpBufferCounter -= Time.deltaTime;
        if (IsGrounded()) {
            coyoteTimeCounter = coyoteTime;
        }
        else {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate() {
        if (jumpBufferCounter > 0) {
            Debug.Log(jumpBufferCounter);
        }
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f) {
            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);

        }
    }

    // void OnDrawGizmos() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    // }

    bool IsGrounded() {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask);
    }
}
