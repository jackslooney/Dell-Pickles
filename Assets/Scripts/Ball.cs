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

        ballStart.x = parent.position.x;
        ballStart.y = parent.position.y - 0.29f;
        ballStart.z = parent.position.z + 0.73f;
        Instantiate(ball, ballStart, parent.rotation);
        
        

        Destroy(gameObject);
    }

    // Activate rigidbody and apply force on tap
    public void ThrowBall()
    {
        rb.useGravity = true;
        rb.AddForce(0, 6, 6, ForceMode.Impulse);
        throwCheck = true;
    }
}
