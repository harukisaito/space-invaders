using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody2D ship;

	// Use this for initialization
	void Start () {
		ship = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		if(GameControl.instance.ShipDestroyed == false)
		{
			ship.velocity = Vector2.zero;
			float moveHorizontal = Input.GetAxis("Horizontal");
			Vector2 movement = new Vector2(moveHorizontal, 0f);

			ship.AddForce(movement * speed);
		}
	}

	void OnCollisionEnter2D()
	{
		speed = 0;
	}

	public void GoToObjectPool()
	{
		transform.position = GameControl.instance.ShipPoolPos;

		if(GameControl.instance.PlayerLifes > 0)
		{
			Invoke("GoToStartPosition", 1.0f);
		}
	}

	private void GoToStartPosition()
	{
		transform.position = GameControl.instance.ShipStartPos;
	}

}
