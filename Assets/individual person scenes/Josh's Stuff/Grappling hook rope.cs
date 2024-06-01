using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapplinghookrope : MonoBehaviour
{

    public GameObject player;

    public int ropeSpeed;

    public int liveTime;

    public int currentTime = 0;

    public Vector3 mousePos;

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
        if (currentTime*Time.deltaTime == liveTime)
        {
            Destroy(this.gameObject);
        }
        this.gameObject.transform.position += this.transform.right * ropeSpeed * Time.deltaTime;
        this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + ropeSpeed * Time.deltaTime * 2,
                                                           this.gameObject.transform.localScale.y,
                                                           this.gameObject.transform.localScale.z);
        currentTime++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
