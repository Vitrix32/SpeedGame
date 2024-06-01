using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject rope;

    public GameObject GH;

    public float grappleSpeed;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        GH = GameObject.FindGameObjectWithTag("GH");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject ropeBoi = Instantiate(rope, this.transform.position, this.transform.rotation);
            ropeBoi.transform.parent = this.transform;
        }
    }

    public void GrappleToPoint(Vector3 p)
    {
        var hookDir = p - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(hookDir.y, hookDir.x) * Mathf.Rad2Deg;
        GH.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        rb.velocity = new Vector2(GH.transform.right.x, GH.transform.right.y) * grappleSpeed;
    }
}
