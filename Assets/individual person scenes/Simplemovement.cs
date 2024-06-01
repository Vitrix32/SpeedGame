using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simplemovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jumpHeight;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        };

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);
    }
}
