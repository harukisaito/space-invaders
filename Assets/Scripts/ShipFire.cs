using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFire : MonoBehaviour
{
	[SerializeField]
	private GameObject projectile;
	
	[SerializeField]
	private int bulletSpeed;
	[SerializeField]
	private float fireRate = 1;
	private float timer;


	void Update () {

		timer += Time.deltaTime;
		if(timer >= fireRate)
		{
			if(Input.GetKeyDown(KeyCode.X))
			{
				Shoot();
				timer = 0;
			}
		}
	}

	public void Shoot()
	{
		if(GameControl.instance.ShipDestroyed == false)
		{
			GameObject bullet = Instantiate(projectile, transform.position + Vector3.up * 0.5f, Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
		}
	}
}
