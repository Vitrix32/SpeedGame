using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour {
    // Start is called before the first frame update
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void OnMove(InputValue value) {
        float v = value.Get<float>();
        animator.SetBool("run", v != 0);
        spriteRenderer.flipX = (v < 0 || (spriteRenderer.flipX == true && v == 0));
    }
}
