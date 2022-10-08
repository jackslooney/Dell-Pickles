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


    
    [SerializeField]
    private Transform parent;

    private Vector3 ballStart = new Vector3();
    void Start()
    {
        ball.transform.SetParent(parent);
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
        rb.useGravity = false;
        throwCheck = false;
        rb = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
       
    }

    //cup detection
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cup")
        {
            Destroy(other.gameObject);
        }

        ballStart = parent.position + (parent.forward*0.75f) - (parent.up * 0.25f);
        Instantiate(ball, ballStart, parent.rotation);
        Destroy(gameObject);
    }

    // Activate rigidbody and apply force on tap
    public void ThrowBall()
    {
        rb.useGravity = true;
        rb.AddRelativeForce(Vector3.forward * 5, ForceMode.Impulse);
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        throwCheck = true;
    }
}
