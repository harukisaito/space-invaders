using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
	[SerializeField]
	private GameObject projectilePrefab;

	[SerializeField]
	private float shootingSpeed;

	public void Fire()
	{
		if(GameControl.instance.PlayerLifes > 0)
		{
			GameObject projectile = Instantiate(projectilePrefab, transform.position + Vector3.down * 0.5f, Quaternion.identity);
			projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.down * shootingSpeed);
		}
	}
}
