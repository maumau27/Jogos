using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {
    public GameObject bullet;

    public float bulletSpeed;
    public float bulletRadius;

    Vector3 playerSize;

	// Use this for initialization
	void Start () {
        playerSize = GetComponent<MeshRenderer>().bounds.size;

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone;
            bulletClone = Instantiate(bullet, transform);
        }
	}
}
