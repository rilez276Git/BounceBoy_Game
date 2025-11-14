using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy3 : MonoBehaviour
{


int collisionCount = 0;


void OnCollisionEnter(Collision collision)
{
  
  collisionCount ++;

  if (collisionCount == 4)
  {
	Destroy(gameObject);
  }
}

}
