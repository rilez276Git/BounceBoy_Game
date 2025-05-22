using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDestruction : MonoBehaviour
{
	int collisionCount = 0;

	void OnCollisionEnter(Collision collision)
	{
  
	  collisionCount ++;

	  if (collisionCount == 2)
	  {
		Destroy(gameObject);
	  }
	}
	
}
