using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

public GameObject bullet;
public GameObject heldbullet;
public GameObject chargedbullet;

public float bulletSpeed = 10.0f;
public float chargeTime = 0.0f;

public float shotCoolDown;
public float shotCoolTime;

public Image chargeBar;
public Image cooldownBar;

private float currentCharge;
private float maxCharge;

private float currentCooldown;
private float maxCooldown;

public AudioSource audioSrc;
public AudioClip gunShot;


private GameObject bulletSpawn;

	void Start ()
		{
			bulletSpawn = GameObject.Find("BulletSpawn");
			chargeTime = 0.0f;
			shotCoolTime = 0f;
			maxCharge = 3.0f;
			maxCooldown = shotCoolDown;
		}

	void Update ()
		{
			
			currentCharge = chargeTime;
			chargeBar.fillAmount = (float)currentCharge / (float)maxCharge;

			currentCooldown = shotCoolTime;
			cooldownBar.fillAmount = (float)shotCoolTime / (float)maxCooldown;
			shotCoolTime -= Time.deltaTime;
			
			if (shotCoolTime < 0.0f)
			{
				shotCoolTime = 0.0f;
			}

			if (shotCoolTime <= 0.0f)
			{
				charge();
			}
		}

	public void charge()
	{
			if(Input.GetMouseButton(0))
			{
				chargeTime += Time.deltaTime;

				if (Input.GetMouseButtonDown(0) && chargeTime >= 1.0f && chargeTime <= 2.0f)
				{
					GameObject tempBullet = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
					tempBullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * bulletSpeed;
					chargeTime = 0.0f;
					shotCoolTime = shotCoolDown;
					audioSrc.clip = gunShot;
					audioSrc.Play();
				}
				else

				if (Input.GetMouseButtonDown(0) && chargeTime >= 2.0f && chargeTime <= 3.0f)
				{
					GameObject tempBullet = Instantiate(heldbullet, bulletSpawn.transform.position, Quaternion.identity);
					tempBullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * bulletSpeed;
					chargeTime = 0.0f;
					shotCoolTime = shotCoolDown;
					shotCoolTime = shotCoolDown;
					audioSrc.clip = gunShot;
					audioSrc.Play();
				}
				else

				if (Input.GetMouseButtonDown(0) && chargeTime >= 3.0f)
				{
					GameObject tempBullet = Instantiate(chargedbullet, bulletSpawn.transform.position, Quaternion.identity);
					tempBullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * bulletSpeed;
					chargeTime = 0.0f;
					shotCoolTime = shotCoolDown;
					shotCoolTime = shotCoolDown;
					audioSrc.clip = gunShot;
					audioSrc.Play();
				}
			}	
	}
}
