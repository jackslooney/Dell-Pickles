using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Collider coll;
    public bool useGravity = false;
    public Rigidbody rb;
    public bool throwCheck = false;

    [SerializeField]
    private GameObject ball;


    private Vector3 ballStart = new Vector3(0.02523589f, 0.0204134f, 1.0533f);
    [SerializeField]
    private Transform parent;
    void Start()
    {
        
        ball.transform.SetParent(parent);
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
        rb.useGravity = false;
        throwCheck = false;
        rb = GetComponent<Rigidbody>();
    }

    // Activate rigidbody and apply force on tap
    void Update()
    {
        
        if (Input.GetKeyDown("space") && throwCheck == false)
        {
            rb.useGravity = true;
            rb.AddForce(0, 6, 6, ForceMode.Impulse);
            throwCheck = true;
        }
    }

    //cup detection
    private void OnTriggerEnter(Collider other)
    {  
        if (other.tag == "Cup")
        {
            Destroy(other.gameObject);
        }
        //Vector3 ballStart = new Vector3(0.02523589f, 0.0204134f, 1.0533f);
        Instantiate(ball, ballStart, ball.transform.rotation);
        
        Destroy(gameObject);
    }
}
