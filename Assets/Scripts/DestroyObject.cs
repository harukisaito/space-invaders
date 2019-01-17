using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
	private Vector2 objectPoolPosition = new Vector2(-10f, -10f);

	[SerializeField]
	private GameObject pointsPrefab;


	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Destroy(Instantiate(pointsPrefab, other.transform.position, Quaternion.identity), 0.5f); 
			Destroy(other.gameObject);
			GameControl.instance.InvaderCount--;
			GameControl.instance.Score += 100;
		}
		if(other.gameObject.tag == "Ship")
		{
			other.GetComponent<Ship>().GoToObjectPool();
			GameControl.instance.PlayerLifes--;
		}
		if(other.gameObject.tag == "Shield")
		{
			other.gameObject.transform.position = objectPoolPosition;
		}
		if(other.gameObject.tag == "RedEnemy")
		{
			Destroy(other.gameObject);
			if(GameControl.instance.PlayerLifes < 3)
			{
				GameControl.instance.PlayerLifes++;
			}
		}
	}

}
