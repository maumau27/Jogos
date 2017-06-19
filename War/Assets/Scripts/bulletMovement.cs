using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour {

    public float speed = 20;
    public float distance = 100;

    Vector3 initialPosition;
    Vector3 CurrentPosition;
    float travaledDistance;

    // Use this for initialization
    void Start () {
        initialPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        CurrentPosition = initialPosition - transform.position;
        travaledDistance = Mathf.Abs(CurrentPosition.x) + Mathf.Abs(CurrentPosition.z);

        if(travaledDistance > distance)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        moveVelocity();
    }

    void moveVelocity()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * speed);
    }
}
