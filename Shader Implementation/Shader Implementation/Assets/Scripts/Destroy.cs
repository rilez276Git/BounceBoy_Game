using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

	public EnemyManager em;

	

	int collisionCount = 0;

	private void OnTriggerEnter()
	{
		if(CompareTag("Enemy"))
		{
			Destroy(gameObject);
		}
	}


	void OnCollisionEnter(Collision collision)
	{
		collisionCount ++;

		if (collisionCount == 2)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			em.enemyCount++;
		}
	}	
}


