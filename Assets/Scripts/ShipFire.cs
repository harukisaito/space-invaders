using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFire : MonoBehaviour
{
	[SerializeField]
	private GameObject projectile;
	
	[SerializeField]
	private int bulletSpeed;

	private GameObject bullet;


	void Update () {

		if(Input.GetKeyDown(KeyCode.X))
		{
			Shoot();
		}
	}

	public void Shoot()
	{
		if(GameControl.instance.ShipDestroyed == false)
		{
			if(bullet == null)
			{
				bullet = Instantiate(projectile, transform.position + Vector3.up * 0.5f, Quaternion.identity) as GameObject;
				bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
			}
		}
	}
}
