using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAITank : MonoBehaviour
{
	public GameObject enemybullet;
	public float bulletSpeed = 10.0f;
	public GameObject enemyBulletSpawn;
	
   public NavMeshAgent agent;
   public Transform player;
   public LayerMask whatIsGround, whatIsPlayer;
   public float health;

   public Vector3 walkPoint;
   bool walkPointSet;
   public float walkPointRange;

   public float timeBetweenAttacks;
   bool alreadyAttacked;

   public float sightRange, attackRange;
   public bool playerInSightRange, playerInAttackRange;

   public AudioSource audioSrc;
   public AudioClip enemyFire;
   public AudioClip enemyDestroy;

   void start()
   {
		  enemyBulletSpawn = GameObject.Find("EnemyBulletSpawn");
   }

   private void Awake()
   {
		  player = GameObject.Find("PlayerObject").transform;
		  agent = GetComponent<NavMeshAgent>();	  
   }

   private void OnTriggerEnter()
	{
		if(CompareTag("Enemy"))
		{
			audioSrc.clip = enemyDestroy;
			audioSrc.Play();
		}
	}

   private void Update()
   {
		  playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		  playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

		  if (!playerInSightRange && !playerInAttackRange) Patroling();
		  if (playerInSightRange && !playerInAttackRange) ChasePlayer();
		  if (playerInSightRange && playerInAttackRange) AttackPlayer();
   }

   private void Patroling()
   {
		if (!walkPointSet) SearchWalkPoint();

		if (walkPointSet)
			agent.SetDestination(walkPoint);

		Vector3 distanceToWalkPoint = transform.position - walkPoint;

		if (distanceToWalkPoint.magnitude < 10f)
			walkPointSet = false;
   }

   private void SearchWalkPoint()
   {
		  float randomZ = Random.Range(-walkPointRange, walkPointRange);
		  float randomX = Random.Range(-walkPointRange, walkPointRange);

		  walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

		  if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
			walkPointSet = true;
   }

   private void ChasePlayer()
   {
		agent.SetDestination(player.position);
   }

   private void AttackPlayer()
   {
		agent.SetDestination(transform.position);

		transform.LookAt(player);

		if (!alreadyAttacked)
		{
			GameObject tempBullet = Instantiate(enemybullet, enemyBulletSpawn.transform.position, Quaternion.identity);
			tempBullet.GetComponent<Rigidbody>().velocity = enemyBulletSpawn.transform.forward * bulletSpeed;

			audioSrc.clip = enemyFire;
			audioSrc.Play();

			alreadyAttacked = true;
			Invoke(nameof(ResetAttack), timeBetweenAttacks);
		}
   }

   private void ResetAttack()
   {
		alreadyAttacked = false;
   }

   public void TakeDamage(int damage)
   {
		  health -= damage;

		  if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
   }

   private void DestroyEnemy()
   {
		  Destroy(gameObject);
   }

   private void OnDrawGizmosSelected()
   {
		  Gizmos.color = Color.red;
		  Gizmos.DrawWireSphere(transform.position, attackRange);
		  Gizmos.color = Color.yellow;
		  Gizmos.DrawWireSphere(transform.position, sightRange);
   }
}
