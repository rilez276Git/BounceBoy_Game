using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

public Transform Firepoint;
public GameObject bullet, chargedbullet;


public float bulletSpeed = 10.0f;


[SerializeField] float chargeTime;


	private GameObject bulletSpawn;

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Shoot();
		}

		if(Input.GetMouseButton(0))
		{
			
			chargeTime += Time.deltaTime;
		}

		if (Input.GetMouseButtonUp(0) && (chargeTime >= 1))
		{
			ChargeShot();
		}

		else if (Input.GetMouseButtonUp(0) && (chargeTime < 1))
		{
			chargeTime = 0;
		}
	}

	void Shoot()
	{
		GameObject tempBullet = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
		tempBullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * bulletSpeed;
	}

	void ChargeShot()
	{
		GameObject tempBullet = Instantiate(chargedbullet, bulletSpawn.transform.position, Quaternion.identity);
		tempBullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * bulletSpeed;

		
		chargeTime = 0;
	}
}