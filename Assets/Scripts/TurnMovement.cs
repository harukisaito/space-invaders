using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMovement : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag != "Bullet")
		{
			if(GetComponentInParent<EnemyMovement>().GoingDown == true)
			{
				GetComponentInParent<EnemyMovement>().MoveDown();
				if(GetComponentInParent<EnemyMovement>().GoingRight == true)
				{
					GetComponentInParent<EnemyMovement>().GoingRight = false;
					return;
				}
				if(GetComponentInParent<EnemyMovement>().GoingRight == false)
				{
					GetComponentInParent<EnemyMovement>().GoingRight = true;
				}
			}
		}
	}
} 
