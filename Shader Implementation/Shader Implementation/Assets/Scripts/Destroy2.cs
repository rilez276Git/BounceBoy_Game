using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2 : MonoBehaviour
{


int collisionCount = 0;


void OnCollisionEnter(Collision collision)
{
  
  collisionCount ++;

  if (collisionCount == 3)
  {
	Destroy(gameObject);
  }
}

}
