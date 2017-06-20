using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {
    public GameObject bullet;

    public float shootDelay;
    public float clipSize;
    public float ammo;
    public float reloadTime;

    float shootTimer;
    float reloadTimer;

    Vector3 playerSize;

	// Use this for initialization
	void Start () {
        playerSize = GetComponent<MeshRenderer>().bounds.size;
        ammo = clipSize;
    }
	
	// Update is called once per frame
	void Update () {
        shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && shootTimer >= shootDelay && ammo > 0)
        {
            GameObject bulletClone;

            Vector3 newPos = new Vector3(transform.position.x, transform.position.y);

            bulletClone = Instantiate(bullet, transform.position, transform.rotation);
            shootTimer = 0f;
            ammo--;
        }

        if(ammo == 0)
        {
            reload();
        }
	}

    public void reload()
    {
        reloadTimer += Time.deltaTime;

        if(reloadTimer >= reloadTime)
        {
            ammo = clipSize;
            reloadTimer = 0;
            return;
        }
    }
}
