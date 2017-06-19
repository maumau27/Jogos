using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float speed = 6;
    public float tilt = 0;
    int floorMask;
    float camRayLength = 100f;
    Vector3 movement;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveTransform(h, v);

        //moveVelocity();

        faceMouse();
    }

    void moveVelocity()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
         (
             GetComponent<Rigidbody>().position.x,
             0.0f,
             GetComponent<Rigidbody>().position.z
         );

    }

    void moveTransform(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        GetComponent<Rigidbody>().MovePosition(transform.position + movement);
    }

    void faceMouse()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }
}
