using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapplinghookrope : MonoBehaviour
{

    public GameObject player;

    public int ropeSpeed;

    public Vector3 mousePos;

    public bool moving = true;

    public Vector3 moveDistance = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        mousePos = Input.mousePosition;
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            moveDistance += this.transform.right * ropeSpeed * Time.deltaTime;
            this.transform.position = player.transform.position + moveDistance;
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + ropeSpeed * Time.deltaTime * 2,
                                                               this.gameObject.transform.localScale.y,
                                                               this.gameObject.transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Wall")
            {
                player.GetComponent<PlayerScript>().GrappleToPoint(mousePos);
                Destroy(this.gameObject);
            }
        }   
    }
}
