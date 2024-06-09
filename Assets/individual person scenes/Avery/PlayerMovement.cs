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

    private float moveDir = 0f;

    void OnJump() {
        if (!IsGrounded()) {
            return;
        }
        rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
    }
    void OnMove(InputValue value) {
        moveDir = value.Get<float>();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);
        Debug.Log(moveDir);
        Debug.Log(rb.velocity);
    }

    // void OnDrawGizmos() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    // }

    bool IsGrounded() {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask);
    }
}
