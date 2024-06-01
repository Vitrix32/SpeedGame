using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jumpHeight;

    private Rigidbody2D rb;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            isGrounded = false;
        };

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }
}
