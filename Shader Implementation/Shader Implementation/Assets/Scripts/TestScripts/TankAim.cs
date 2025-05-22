using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAim : MonoBehaviour
{
    
    
    private Transform target;
    private SphereCollider spherecollider;
    private bool targetInRange = false;
    private GameObject tankBulletSpawn;
    public float bulletSpeed = 10f;
    public GameObject enemyBullet;

    private float coolDown;
    private const float lastShot = 1f;
    

    [SerializeField] Transform turretPivot;

    [SerializeField] float targetingRange = 6f;
    [SerializeField] float turningSpeed = 5f;

   

    void Start()
    {
        spherecollider = GetComponent<SphereCollider>();
        spherecollider.radius = targetingRange;
        tankBulletSpawn = GameObject.Find("TankBulletSpawn");
    }

    void Update()
    {
        Aim();
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

    private void Aim()
    {

        if (targetInRange)
        {
            Vector3 direction = (target.position - turretPivot.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            turretPivot.rotation = Quaternion.Slerp(turretPivot.rotation, lookRotation, turningSpeed * Time.deltaTime);

                
                
            if (coolDown <= 0)
            {
                coolDown = lastShot;
                GameObject tempBullet = Instantiate(enemyBullet, tankBulletSpawn.transform.position, Quaternion.identity);
		        tempBullet.GetComponent<Rigidbody>().velocity = tankBulletSpawn.transform.forward * bulletSpeed;
            }
         
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetInRange = true;
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetInRange = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }

}
