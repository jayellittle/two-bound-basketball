using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballController : MonoBehaviour
{
    private Rigidbody rb;
    private int bounce;
    private GameObject cam;
    private GameObject goal;

    void Start()
    {
        bounce = 0;
        rb = GetComponent<Rigidbody>();
        goal = GameObject.Find("Goal");
    }

    void Update()
    {
        cam = GameObject.Find("Camera");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            transform.position = new Vector3((float)-13, (float)0.11, (float)0.02);
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (other.gameObject.CompareTag("Out"))
        {
            transform.position = new Vector3((float)-13, (float)0.11, (float)0.02);
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (other.gameObject.CompareTag("Court"))
        {
            bounce++;
            if (bounce >= 2) {
                rb.velocity = new Vector3(0, 0, 0);
                cam.transform.position = transform.position;
                bounce = 0;
            }
        }
    }
}
